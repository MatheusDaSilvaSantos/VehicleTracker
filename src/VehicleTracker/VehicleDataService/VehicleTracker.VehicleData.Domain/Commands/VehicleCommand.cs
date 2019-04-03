using System;
using VehicleTracker.Abstract.Domain.Core.Commands;

namespace VehicleTracker.VehicleData.Domain.Commands
{
    public abstract class VehicleCommand : Command
    {

        public Guid Id { get; protected set; }
        public string VehicleId { get; protected set; }
        public string RegNumber { get; protected set; }
        public Guid CustomerId { get; protected set; }

    }
}