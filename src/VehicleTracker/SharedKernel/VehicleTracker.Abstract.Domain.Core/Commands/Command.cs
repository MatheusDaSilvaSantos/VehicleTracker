using System;
using FluentValidation.Results;
using VehicleTracker.Abstract.Domain.Core.Events;

namespace VehicleTracker.Abstract.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}