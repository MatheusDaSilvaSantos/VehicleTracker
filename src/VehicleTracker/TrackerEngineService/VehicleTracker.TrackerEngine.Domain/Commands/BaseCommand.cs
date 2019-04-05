using System;
using VehicleTracker.Abstract.Domain.Core.Commands;

namespace VehicleTracker.TrackerEngine.Domain.Commands
{
    public abstract class BaseCommand : Command
    {
        public Guid Id { get; protected set; }
        public string VehicleId { get; protected set; }
        public TimeSpan PingTime { get; protected set; }
    }
}