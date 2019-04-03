using System;
using VehicleTracker.Abstract.Domain.Core.Events;

namespace VehicleTracker.VehicleData.Domain.Events
{
    public class VehicleUpdatedEvent : Event
    {
        public VehicleUpdatedEvent(Guid id, string vehicleId, string regNumber, Guid customerId)
        {
            Id = id;
            VehicleId = vehicleId;
            RegNumber = regNumber;
            CustomerId = customerId;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string VehicleId { get; private set; }
        public string RegNumber { get; private set; }
        public Guid CustomerId { get; private set; }
    }
}