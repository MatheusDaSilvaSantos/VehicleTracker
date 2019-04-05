using System;

namespace VehicleTracker.TrackerEngine.Application.ViewModels
{
    public class VehiclePingViewModel
    {
        public VehiclePingViewModel()
        {
            Id = Guid.NewGuid();
            PingTime = DateTime.Now.TimeOfDay;
        }
        public Guid Id { get; set; }

        public string VehicleId { get; set; }

        public TimeSpan PingTime { get; set; }
    }
}
