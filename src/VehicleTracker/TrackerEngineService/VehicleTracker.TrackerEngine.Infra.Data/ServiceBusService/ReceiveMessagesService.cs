using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using VehicleTracker.Abstract.Domain.Core.Events;
using VehicleTracker.TrackerEngine.Domain.Interfaces;

namespace VehicleTracker.TrackerEngine.Infra.Data.ServiceBusService
{
    public class ReceiveMessagesService : IReceiveMessagesService
    {
        //private readonly QueueClient _client;
        private readonly CloudQueueClient _client;
        private readonly CloudQueue _cloudQueue;
        private readonly IConfiguration _configuration;
        public ReceiveMessagesService(IConfiguration configuration)
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

        public async Task DequeueMessageAsync()
        {
            var retrievedMessage = await _cloudQueue.GetMessageAsync();

            await _cloudQueue.DeleteMessageAsync(retrievedMessage);
        }
    }

}
