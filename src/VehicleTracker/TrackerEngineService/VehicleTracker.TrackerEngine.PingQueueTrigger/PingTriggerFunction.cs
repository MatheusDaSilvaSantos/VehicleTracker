using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VehicleTracker.TrackerEngine.PingQueueTrigger.TrackerEngineServiceClient;
using VehicleTracker.TrackerEngine.PingQueueTrigger.TrackerEngineServiceClient.Models;

namespace VehicleTracker.TrackerEngine.PingQueueTrigger
{
    public static class PingTriggerFunction
    {
        [FunctionName("PingTriggerFunction")]
        public static void Run([QueueTrigger("pingqueue", Connection = "AzureWebJobsStorage")]string pingQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {pingQueueItem}");


            var queueItem = JsonConvert.DeserializeObject<RequestQueueItem>(pingQueueItem);

            // call engine api 
            var apiUrl = new Uri("https://localhost:44303");

            var client = new TrackerEngineService(apiUrl);
            var pingViewModel = new VehiclePingViewModel
            {
                VehicleId = queueItem.VehicleId,
                PingTime = queueItem.PingTime,
                Id = queueItem.Id
            };
            client.ReceivePing("1", pingViewModel);
        }
    }
}
