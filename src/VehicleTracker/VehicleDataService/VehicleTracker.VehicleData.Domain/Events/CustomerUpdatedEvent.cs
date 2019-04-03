using System;
using VehicleTracker.Abstract.Domain.Core.Events;

namespace VehicleTracker.VehicleData.Domain.Events
{
    public class CustomerUpdatedEvent : Event
    {
        public CustomerUpdatedEvent(Guid id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Address { get; private set; }

    }
}