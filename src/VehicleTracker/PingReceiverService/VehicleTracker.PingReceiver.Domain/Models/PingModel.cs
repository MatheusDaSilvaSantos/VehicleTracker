using System;
using VehicleTracker.Abstract.Domain.Core.Models;

namespace VehicleTracker.PingReceiver.Domain.Models
{
    public class PingModel : Entity
    {
        public PingModel(Guid id, string vehicleId, DateTime pingTime)
        {
            Id = id;
            VehicleId = vehicleId;
            PingTime = pingTime;

        }

        public string VehicleId { get; protected set; }

        public DateTime PingTime { get; protected set; }
    }
}