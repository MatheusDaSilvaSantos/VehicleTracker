using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Notifications;
using VehicleTracker.TrackerEngine.Domain.Commands;
using VehicleTracker.TrackerEngine.Domain.Events;
using VehicleTracker.TrackerEngine.Domain.Interfaces;
using VehicleTracker.TrackerEngine.Domain.Models;


namespace VehicleTracker.TrackerEngine.Domain.CommandHandlers
{
    public class VehiclePingCommandHandler : CommandHandler,
        IRequestHandler<VehiclePingCommand, bool>
    {

        private readonly IReceiveMessagesService _receiveMessagesService;
        private readonly IVehiclesConnectionStatusRepository _vehiclesConnectionStatusRepository;
        private readonly IMediatorHandler _bus;



        public VehiclePingCommandHandler(IReceiveMessagesService receiveMessagesService,
                                         IMediatorHandler bus,
                                         INotificationHandler<DomainNotification> notifications, IVehiclesConnectionStatusRepository vehiclesConnectionStatusRepository) : base(bus, notifications)
        {
            _bus = bus;
            _vehiclesConnectionStatusRepository = vehiclesConnectionStatusRepository;
            _receiveMessagesService = receiveMessagesService;
        }

        public Task<bool> Handle(VehiclePingCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _receiveMessagesService.DequeueMessageAsync();

            _vehiclesConnectionStatusRepository.SaveAsync(new VehiclesConnectionStatus(message.VehicleId, message.PingTime.ToString()));

            _bus.RaiseEvent(new VehiclePingedEvent(message.Id, message.VehicleId, message.PingTime));

            return Task.FromResult(true);
        }


    }
}