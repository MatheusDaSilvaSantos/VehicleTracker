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
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<AddNewCustomerCommand, bool>,
        IRequestHandler<UpdateCustomerCommand, bool>,
        IRequestHandler<RemoveCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler _bus;

        public CustomerCommandHandler(ICustomerRepository customerRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;
            _bus = bus;
        }

        public Task<bool> Handle(AddNewCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var customer = new Customer(Guid.NewGuid(), message.Name, message.Address);


            _customerRepository.Add(customer);

            if (Commit())
            {
                _bus.RaiseEvent(new CustomerAddedEvent(customer.Id, customer.Name, customer.Address));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var customer = new Customer(message.Id, message.Name, message.Address);

            _customerRepository.Update(customer);

            if (Commit())
            {
                _bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Address));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _customerRepository.Remove(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new CustomerRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}