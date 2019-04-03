using System;
using VehicleTracker.Abstract.Domain.Core.Models;

namespace VehicleTracker.PingReceiver.Domain.Models
{
    public class PingAction : Entity
    {
        public PingAction(Guid id, string vehicleId, string email, DateTime birthDate)
        {
            Id = id;
            VehicleId = vehicleId;
            Email = email;
            BirthDate = birthDate;
        }

        public string VehicleId { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}