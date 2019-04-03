using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VehicleTracker.PingReceiver.Domain.Events;

namespace VehicleTracker.PingReceiver.Domain.EventHandlers
{
    public class PingEventHandler :
        INotificationHandler<VehiclePingedEvent>
    {
        public Task Handle(VehiclePingedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification 

            return Task.CompletedTask;
        }

    }
}