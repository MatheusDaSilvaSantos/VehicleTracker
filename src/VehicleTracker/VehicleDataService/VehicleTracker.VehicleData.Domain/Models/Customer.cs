using System;
using System.Collections.Generic;
using VehicleTracker.Abstract.Domain.Core.Models;

namespace VehicleTracker.VehicleData.Domain.Models
{
    public class Customer : Entity
    {
        public Customer(Guid id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;

        }

        // Empty constructor for EF
        protected Customer() { }

        public string Name { get; private set; }

        public string Address { get; private set; }
        public virtual ICollection<Vehicle> Vehicles  { get; set; }

    }
}