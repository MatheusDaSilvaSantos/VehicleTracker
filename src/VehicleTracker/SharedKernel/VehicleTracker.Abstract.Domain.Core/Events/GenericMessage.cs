using System;
using MediatR;

namespace VehicleTracker.Abstract.Domain.Core.Events
{
    public abstract class GenericMessage<TResponse> : IRequest<TResponse>
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected GenericMessage()
        {
            MessageType = GetType().Name;
        }
    }
}