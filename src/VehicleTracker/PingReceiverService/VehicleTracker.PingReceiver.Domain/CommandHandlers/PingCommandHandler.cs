using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.Abstract.Domain.Core.Notifications;
using VehicleTracker.PingReceiver.Domain.Commands;
using VehicleTracker.PingReceiver.Domain.Events;
using VehicleTracker.PingReceiver.Domain.Interfaces;
using VehicleTracker.PingReceiver.Domain.Models;

namespace VehicleTracker.PingReceiver.Domain.CommandHandlers
{
    public class PingCommandHandler : CommandHandler,
        IRequestHandler<PingCommand, bool>
    {
        private readonly ISendMessagesService _sendMessagesService;
        private readonly IMediatorHandler _bus;

        public PingCommandHandler(ISendMessagesService sendMessagesService,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(null, bus, notifications)
        {
            _sendMessagesService = sendMessagesService;
            _bus = bus;
        }

        public Task<bool> Handle(PingCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _sendMessagesService.SendMessageAsync<PingCommand>(message);

            if (Commit())
            {
                _bus.RaiseEvent(new VehiclePingedEvent(message.Id, message.VehicleId, message.PingTime));
            }

            return Task.FromResult(true);
        }


    }
}