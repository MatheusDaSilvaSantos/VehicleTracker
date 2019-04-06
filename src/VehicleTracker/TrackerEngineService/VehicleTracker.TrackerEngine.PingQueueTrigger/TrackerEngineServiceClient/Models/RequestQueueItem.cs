using System;

namespace VehicleTracker.TrackerEngine.PingQueueTrigger.TrackerEngineServiceClient.Models
{
    public class RequestQueueItem
    {
        public Guid Id { get; set; }
        public string VehicleId { get; set; }
        public DateTime PingTime { get; set; }
        public string Timestamp { get; set; }

    
    }
}