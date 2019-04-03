using System;
using VehicleTracker.Abstract.Domain.Core.Events;

namespace VehicleTracker.VehicleData.Domain.Events
{
    public class VehicleRemovedEvent : Event
    {
        public VehicleRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}