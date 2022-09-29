﻿using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace SendMessage
{
    public static class SendMessage
    {
        [FunctionName("SendMessage")]
        public static void Run([ServiceBusTrigger("messages", Connection = "ServiceBus")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
