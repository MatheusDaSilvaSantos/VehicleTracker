using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace VehicleTracker.TrackerEngine.PingQueueTrigger
{
    public static class PingTriggerFunction
    {
        [FunctionName("PingTriggerFunction")]
        public static void Run([QueueTrigger("pingqueue", Connection = "")]string pingQueueItem, TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {pingQueueItem}");
        }
    }
}
