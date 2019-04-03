using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.Abstract.Domain.Core.Notifications;
using VehicleTracker.VehicleData.Domain.Commands;
using VehicleTracker.VehicleData.Domain.Events;
using VehicleTracker.VehicleData.Domain.Interfaces;
using VehicleTracker.VehicleData.Domain.Models;

namespace VehicleTracker.VehicleData.Domain.CommandHandlers
{
    public class VehicleCommandHandler : CommandHandler,
        IRequestHandler<AddNewVehicleCommand, bool>,
        IRequestHandler<UpdateVehicleCommand, bool>,
        IRequestHandler<RemoveVehicleCommand, bool>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMediatorHandler _bus;

        public VehicleCommandHandler(IVehicleRepository vehicleRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _vehicleRepository = vehicleRepository;
            _bus = bus;
        }

        public Task<bool> Handle(AddNewVehicleCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var vehicle = new Vehicle(Guid.NewGuid(), message.VehicleId, message.RegNumber, message.CustomerId);


            _vehicleRepository.Add(vehicle);

            if (Commit())
            {
                _bus.RaiseEvent(new VehicleAddedEvent(vehicle.Id, vehicle.VehicleId, vehicle.RegNumber, vehicle.CustomerId));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateVehicleCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var vehicle = new Vehicle(Guid.NewGuid(), message.VehicleId, message.RegNumber, message.CustomerId);

            _vehicleRepository.Update(vehicle);

            if (Commit())
            {
                _bus.RaiseEvent(new VehicleUpdatedEvent(vehicle.Id, vehicle.VehicleId, vehicle.RegNumber, vehicle.CustomerId));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveVehicleCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _vehicleRepository.Remove(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new VehicleRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _vehicleRepository.Dispose();
        }
    }
}