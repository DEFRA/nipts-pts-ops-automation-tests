using Defra.UI.Framework.Object;
using Defra.UI.Tests.Tools;
using Reqnroll;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using static Defra.UI.Tests.Tools.GovernmentGateway;

namespace Defra.UI.Tests.HelperMethods
{
    public interface IFetchCodeFromEmail
    {
        public Task<string> GetCodeFromEmail(string inboxIdToReadCode);        
        public Task<MailAccount> CreateAccount();
    }

    public class FetchCodeFromEmail : IFetchCodeFromEmail
    {
        private ScenarioContext ScenarioContext { get; set; }

        public FetchCodeFromEmail(ScenarioContext _scenarioContext)
        {
            ScenarioContext = _scenarioContext;
        }
        
        public async Task<MailAccount> CreateAccount()
        {
            using var client = new HttpClient();

            var domainResponse = await client.GetAsync("https://api.mail.tm/domains");
            domainResponse.EnsureSuccessStatusCode();

            var domainJson = await domainResponse.Content.ReadAsStringAsync();
            using var domainDocument = JsonDocument.Parse(domainJson);

            var domains = domainDocument.RootElement.GetProperty("hydra:member");
            if (domains.GetArrayLength() == 0)
            {
                throw new InvalidOperationException("Mail.tm returned no available domains.");
            }

            var domain = domains[0].GetProperty("domain").GetString();
            if (string.IsNullOrWhiteSpace(domain))
            {
                throw new InvalidOperationException("Mail.tm returned an invalid domain.");
            }

            var username = $"pets{DateTime.UtcNow:HHmmssfff}";
            var emailAddress = $"{username}@{domain}";           
            var emailKey = Utils.GenerateRandomKey(12);

            Utils.AppendToLoginLog(("Email ID", emailAddress));
            Utils.AppendToLoginLog(("Email Key", emailKey));

            var accountRequest = new
            {
                address = emailAddress,
                password = emailKey
            };

            var accountContent = new StringContent(
                JsonSerializer.Serialize(accountRequest),
                Encoding.UTF8,
                "application/json");

            var accountResponse = await client.PostAsync("https://api.mail.tm/accounts", accountContent);
            var accountResponseBody = await accountResponse.Content.ReadAsStringAsync();

            if (!accountResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"Mail.tm account creation failed: {(int)accountResponse.StatusCode} ({accountResponse.ReasonPhrase}). Response: {accountResponseBody}");
            }

            var tokenRequest = new
            {
                address = emailAddress,
                password = emailKey
            };

            var tokenContent = new StringContent(
                JsonSerializer.Serialize(tokenRequest),
                Encoding.UTF8,
                "application/json");

            var tokenResponse = await client.PostAsync("https://api.mail.tm/token", tokenContent);
            var tokenResponseBody = await tokenResponse.Content.ReadAsStringAsync();

            if (!tokenResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"Mail.tm token request failed: {(int)tokenResponse.StatusCode} ({tokenResponse.ReasonPhrase}). Response: {tokenResponseBody}");
            }

            using var tokenDocument = JsonDocument.Parse(tokenResponseBody);
            var token = tokenDocument.RootElement.GetProperty("token").GetString();

            using var verifyClient = new HttpClient();
            verifyClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var meResponse = await verifyClient.GetAsync("https://api.mail.tm/me");
            var meBody = await meResponse.Content.ReadAsStringAsync();

            if (!meResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"Mail.tm /me verification failed: {(int)meResponse.StatusCode} ({meResponse.ReasonPhrase}). Response: {meBody}");
            }

            Logger.LogMessage($"Mail.tm account created: {emailAddress}");

            return new MailAccount
            {
                EmailAddress = emailAddress,
                Token = token,
                Password = emailKey
            };
        }       

        public async Task<string> GetCodeFromEmail(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("Mail.tm token is empty.", nameof(token));
            }

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var meResponse = await client.GetAsync("https://api.mail.tm/me");
            var meBody = await meResponse.Content.ReadAsStringAsync();

            if (!meResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"Mail.tm /me failed: {(int)meResponse.StatusCode} ({meResponse.ReasonPhrase}). Response: {meBody}");
            }

            for (var attempt = 0; attempt < 24; attempt++) 
            {
                var messagesResponse = await client.GetAsync("https://api.mail.tm/messages?page=1");
                var messagesJson = await messagesResponse.Content.ReadAsStringAsync();

                if (!messagesResponse.IsSuccessStatusCode)
                {
                    Logger.LogMessage($"Mail.tm messages failed: {(int)messagesResponse.StatusCode} {messagesResponse.ReasonPhrase} - {messagesJson}");
                    await Task.Delay(5000);
                    continue;
                }

                using var messagesDoc = JsonDocument.Parse(messagesJson);
                var members = messagesDoc.RootElement.GetProperty("hydra:member");

                for (var i = 0; i < members.GetArrayLength(); i++)
                {
                    var messageId = members[i].GetProperty("id").GetString();
                    if (string.IsNullOrWhiteSpace(messageId))
                    {
                        continue;
                    }

                    var messageResponse = await client.GetAsync($"https://api.mail.tm/messages/{messageId}");
                    var messageJson = await messageResponse.Content.ReadAsStringAsync();

                    if (!messageResponse.IsSuccessStatusCode)
                    {
                        continue;
                    }

                    using var messageDoc = JsonDocument.Parse(messageJson);
                    var root = messageDoc.RootElement;

                    var intro = root.TryGetProperty("intro", out var introNode) && introNode.ValueKind == JsonValueKind.String
                        ? introNode.GetString()
                        : string.Empty;

                    var text = root.TryGetProperty("text", out var textNode) && textNode.ValueKind == JsonValueKind.String
                        ? textNode.GetString()
                        : string.Empty;

                    var html = string.Empty;
                    if (root.TryGetProperty("html", out var htmlNode))
                    {
                        if (htmlNode.ValueKind == JsonValueKind.Array)
                        {
                            foreach (var item in htmlNode.EnumerateArray())
                            {
                                if (item.ValueKind == JsonValueKind.String)
                                {
                                    html += item.GetString();
                                }
                            }
                        }
                        else if (htmlNode.ValueKind == JsonValueKind.String)
                        {
                            html = htmlNode.GetString();
                        }
                    }

                    var content = $"{intro}\n{text}\n{html}";
                    if (TryExtractCode(content, out var code))
                    {
                        return code;
                    }
                }

                await Task.Delay(5000);
            }

            throw new InvalidOperationException("Confirmation code email was not found in Mail.tm within timeout.");

            static bool TryExtractCode(string? content, out string code)
            {
                code = string.Empty;

                if (string.IsNullOrWhiteSpace(content))
                {
                    return false;
                }

                var targeted = Regex.Match(
                    content,
                    @"(?i)confirmation\s*code(?:\s*is)?\s*:\s*([A-Z0-9]{4,12}(?: [A-Z0-9]{2,12}){0,2})");

                if (targeted.Success)
                {
                    var candidate = targeted.Groups[1].Value.Trim();

                    if (Regex.IsMatch(candidate, @"^[A-Z0-9]+(?: [A-Z0-9]+)*$"))
                    {
                        code = candidate;
                        return true;
                    }
                }

                var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var rawLine in lines)
                {
                    var line = rawLine.Trim();

                    if (Regex.IsMatch(line, @"^[A-Z0-9]{4,12}(?: [A-Z0-9]{2,12}){0,2}$"))
                    {
                        code = line;
                        return true;
                    }
                }

                return false;
            }
        }
    }
}