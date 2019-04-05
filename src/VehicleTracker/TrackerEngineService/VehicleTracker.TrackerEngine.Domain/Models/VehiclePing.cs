using System;
using VehicleTracker.Abstract.Domain.Core.Models;

namespace VehicleTracker.TrackerEngine.Domain.Models
{

    public class VehiclePing : Entity
    {
        public VehiclePing(Guid id, string vehicleId, TimeSpan pingTime)
        {
            Id = id;
            VehicleId = vehicleId;
            PingTime = pingTime;

        }
        public string VehicleId { get; protected set; }

        public TimeSpan PingTime { get; protected set; }
    }
}