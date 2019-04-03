using System;
using FluentValidation.Results;
using VehicleTracker.Abstract.Domain.Core.Events;

namespace VehicleTracker.Abstract.Domain.Core.Queries
{
    public abstract class Query<TResponse> : GenericMessage<TResponse>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Query()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}