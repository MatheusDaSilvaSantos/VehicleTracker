using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VehicleTracker.VehicleData.Domain.Events;

namespace VehicleTracker.VehicleData.Domain.EventHandlers
{
    public class VehicleEventHandler :
        INotificationHandler<VehicleAddedEvent>,
        INotificationHandler<VehicleUpdatedEvent>,
        INotificationHandler<VehicleRemovedEvent>
    {
        public Task Handle(VehicleAddedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(VehicleUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(VehicleRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}