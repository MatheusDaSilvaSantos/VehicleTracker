using System;
using VehicleTracker.Abstract.Domain.Core.Models;

namespace VehicleTracker.VehicleData.Domain.Models
{
    public class Vehicle : Entity
    {
        public Vehicle(Guid id, string vehicleId, string regNumber, Guid customerId)
        {
            Id = id;
            VehicleId = vehicleId;
            RegNumber = regNumber;
            CustomerId = customerId;
        }

        // Empty constructor for EF
        protected Vehicle(Guid customerId)
        {
            CustomerId = customerId;
        }

        public string VehicleId { get; private set; }

        public string RegNumber { get; private set; }
        public Guid CustomerId { get; private set; }
        public virtual Customer Customer { get; set; }

    }
}