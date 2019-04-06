namespace VehicleTracker.TrackerEngine.Application.EventSourcedNormalizers
{
    public class VehiclePingHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string VehicleId { get; set; }
        public string PingTime { get; set; }
        public string When { get; set; }
    }


}