using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using VehicleTracker.Abstract.Domain.Core.Events;
using VehicleTracker.PingReceiver.Domain.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace VehicleTracker.PingReceiver.Infra.Data.ServiceBusService
{
    public class SendMessagesService : ISendMessagesService
    {
        //private readonly QueueClient _client;
        private readonly CloudQueueClient _client;
        private readonly CloudQueue _cloudQueue;
        private readonly IConfiguration _configuration;
        public SendMessagesService(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectionString = _configuration.GetSection("StorageConnectionString").Value;
            var queueName = _configuration.GetSection("QueueName").Value;

            var storageAccount = CloudStorageAccount.Parse(connectionString);

            // Create the queue client.
            _client = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a container.
            _cloudQueue = _client.GetQueueReference(queueName);

            // Create the queue if it doesn't already exist
            _cloudQueue.CreateIfNotExistsAsync();

        }



        public async Task SendMessageAsync<T>(T message) where T : Message
        {
            await SendTypedMessageAsync(message, message.AggregateId.ToString());
        }
        public async Task SendAsync<T>(T data, string messageid)
        {
            await SendTypedMessageAsync(data, messageid);
        }

        private async Task SendTypedMessageAsync<T>(T payload, string messageId)
        {
            var label = payload.GetType().Name;
            var msg = WrapWithMessageId(payload, messageId + label, label);
            await _cloudQueue.AddMessageAsync(msg);
        }


        private static CloudQueueMessage WrapWithMessageId<T>(T payload, string messageId, string label)
        {
            var text = JsonConvert.SerializeObject(payload);

            //UTF8Encoding utf8 = new UTF8Encoding();
            //byte[] bytes = utf8.GetBytes(text);
            //var stream = new MemoryStream(bytes, false);

            return new CloudQueueMessage(text);
        }


    }

}
