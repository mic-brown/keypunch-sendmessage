using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;

namespace SendMessage
{
    public static class SendMessage
    {
        [FunctionName("SendMessage")]
        public static async Task Run(
            [ServiceBusTrigger("messages", Connection = "ServiceBus")] ApplicationMessage message,
            [SignalR(HubName = "notifications")] IAsyncCollector<SignalRMessage> signalRMessages)
        {
            if (message.UserId.GetValueOrDefault() == Guid.Empty)
            {
                await signalRMessages.AddAsync(new SignalRMessage()
                {
                    Target="newMessage",
                    Arguments = new[] { message.Arguments }
                });
            }
            else
            {
                await signalRMessages.AddAsync(new SignalRMessage()
                {
                    Target = "newMessage",
                    UserId = message.UserId.ToString(),
                    Arguments = new[] { message.Arguments }
                });
            }
        }
    }
}
