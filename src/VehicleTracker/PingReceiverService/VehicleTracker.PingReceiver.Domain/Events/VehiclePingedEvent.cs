using System;
using VehicleTracker.Abstract.Domain.Core.Events;

namespace VehicleTracker.PingReceiver.Domain.Events
{
    public class VehiclePingedEvent : Event
    {
        public VehiclePingedEvent(Guid id, string vehicleId, TimeSpan pingTime)
        {
            VehicleId = vehicleId;
            PingTime = pingTime;
            AggregateId = id;
        }
        public string VehicleId { get; protected set; }

        public TimeSpan PingTime { get; protected set; }
    }
}