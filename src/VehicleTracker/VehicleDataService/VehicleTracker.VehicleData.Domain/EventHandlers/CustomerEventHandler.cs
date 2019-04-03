﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VehicleTracker.VehicleData.Domain.Events;

namespace VehicleTracker.VehicleData.Domain.EventHandlers
{
    public class CustomerEventHandler :
        INotificationHandler<CustomerAddedEvent>,
        INotificationHandler<CustomerUpdatedEvent>,
        INotificationHandler<CustomerRemovedEvent>
    {
        public Task Handle(CustomerUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(CustomerAddedEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(CustomerRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}