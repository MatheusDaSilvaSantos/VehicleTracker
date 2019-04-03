using System;
using VehicleTracker.Abstract.Domain.Core.Commands;

namespace VehicleTracker.VehicleData.Domain.Commands
{
    public abstract class CustomerCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Address { get; protected set; }


    }
}