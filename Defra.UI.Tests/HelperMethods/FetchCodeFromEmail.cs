using mailinator_csharp_client.Models.Messages.Entities;
using mailinator_csharp_client.Models.Messages.Requests;
using mailinator_csharp_client.Models.Responses;
using mailinator_csharp_client;
using Reqnroll;
using Defra.UI.Framework.Object;

namespace Defra.UI.Tests.HelperMethods
{
    public interface IFetchCodeFromEmail
    {
        public Task<string> GetCodeFromEmail(string inboxIdToReadCode);
        public Task DeleteMessageFromInbox(string inboxId);
        public Task DeleteAllMessagesFromInbox();
        public string DomainName { get; set; }
    }

    public class FetchCodeFromEmail : IFetchCodeFromEmail
    {
        private ScenarioContext ScenarioContext { get; set; }
        public string DomainName { get; set; } = "team947193.testinator.com";

        private MailinatorClient MailinatorClient = new MailinatorClient("e8dd4956d033404498bc790303738870");

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
                Thread.Sleep(15000);
                FetchInboxRequest fetchInboxRequest = new FetchInboxRequest() { Domain = DomainName, Inbox = "*", Skip = 0, Limit = 30, Sort = Sort.asc };
                FetchInboxResponse fetchInboxResponse = await MailinatorClient.MessagesClient.FetchInboxAsync(fetchInboxRequest);

                var inBoxMessage = fetchInboxResponse.Messages.SingleOrDefault(t => t.To.Equals(inboxIdToReadCode));

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

        public async Task DeleteAllMessagesFromInbox()
        {
            try
            {
                await MailinatorClient.MessagesClient.DeleteAllDomainMessagesAsync(new DeleteAllDomainMessagesRequest
                {
                    Domain = DomainName
                });
            }
            catch (Exception ex)
            {
                Logger.LogMessage("While Deleteing the message from Inbox... " + ex.Message);
            }
        }
    }
}