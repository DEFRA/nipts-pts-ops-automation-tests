using mailinator_csharp_client.Models.Messages.Entities;
using mailinator_csharp_client.Models.Messages.Requests;
using mailinator_csharp_client.Models.Responses;
using mailinator_csharp_client;
using TechTalk.SpecFlow;
using Defra.UI.Framework.Object;

namespace Defra.UI.Tests.HelperMethods
{
    public interface IFetchCodeFromEmail
    {
        public Task<string> GetCodeFromEmail(string inboxIdToReadCode);
        public Task DeleteMessageFromInbox(string inboxId);
        public Task DeleteAllMessagesFromInbox(string inboxIdToReadCode);
    }
    public class FetchCodeFromEmail : IFetchCodeFromEmail
    {
        private ScenarioContext ScenarioContext { get; set; }
        private MailinatorClient MailinatorClient = new MailinatorClient("2d0ed433f0b244968a67886a979f48f8");
        private string DomainName = "team999095.testinator.com";

        public FetchCodeFromEmail(ScenarioContext _scenarioContext)
        {
            ScenarioContext = _scenarioContext;
        }

        public async Task<string> GetCodeFromEmail(string inboxIdToReadCode)
        {
            string code = "";
            try
            {
                //Fetch Inbox
                Thread.Sleep(5000);
                FetchInboxRequest fetchInboxRequest = new FetchInboxRequest() { Domain = DomainName, Inbox = "*", Skip = 0, Limit = 30, Sort = Sort.asc };
                FetchInboxResponse fetchInboxResponse = await MailinatorClient.MessagesClient.FetchInboxAsync(fetchInboxRequest);

                var inBoxMessage = fetchInboxResponse.Messages.SingleOrDefault(t => t.To.Equals(inboxIdToReadCode));
                ScenarioContext.Add(inboxIdToReadCode, inBoxMessage?.Id);

                //Fetch Message
                FetchMessageRequest fetchMessageRequest = new FetchMessageRequest() { Domain = DomainName, Inbox = inBoxMessage?.To, MessageId = inBoxMessage?.Id };
                FetchMessageResponse fetchMessageResponse = await MailinatorClient.MessagesClient.FetchMessageAsync(fetchMessageRequest);

                var message = fetchMessageResponse.Parts[0];

                string body = message.Body;
                int pFrom = body.IndexOf("Your confirmation code is:") + "Your confirmation code is:".Length; ;
                int pTo = body.LastIndexOf("This code will expire in 30 minutes");

                code = body.Substring(pFrom, pTo - pFrom).Replace("\r", "").Replace("\n", "");

            }
            catch (Exception ex)
            {
                Logger.LogMessage("While trying to read the message from Inbox... " + ex.Message);
            }

            return code;
        }

        public async Task DeleteMessageFromInbox(string inboxIdToReadCode)
        {
            try
            {
                var messageId = ScenarioContext.Get<string>(inboxIdToReadCode);
                
                DeleteMessageRequest deleteMessageRequest = new DeleteMessageRequest()
                {
                    Domain = DomainName,
                    Inbox = inboxIdToReadCode,
                    MessageId = messageId
                };

                DeleteMessageResponse deleteMessageResponse = await MailinatorClient.MessagesClient.DeleteMessageAsync(deleteMessageRequest);
            }
            catch (Exception ex)
            {
                Logger.LogMessage("While Deleteing the message from Inbox... " + ex.Message);
            }
        }

        public async Task DeleteAllMessagesFromInbox(string inboxIdToReadCode)
        {
            Thread.Sleep(22000);
            try
            {
                var messageId = ScenarioContext.Get<string>(inboxIdToReadCode);

                DeleteAllInboxMessagesRequest deleteAllMessagesRequest = new DeleteAllInboxMessagesRequest()
                {
                    Domain = DomainName,
                    Inbox = inboxIdToReadCode,
                };

                DeleteAllInboxMessagesResponse deleteAllMessagesResponse = await MailinatorClient.MessagesClient.DeleteAllInboxMessagesAsync(deleteAllMessagesRequest);
            }
            catch (Exception ex)
            {
                Logger.LogMessage("While Deleteing the message from Inbox... " + ex.Message);
            }
        }
    }
}