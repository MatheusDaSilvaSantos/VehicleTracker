using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.VehicleData.Application.Interfaces;
using VehicleTracker.VehicleData.Application.ViewModels;
using VehicleTracker.VehicleData.Domain.Commands;
using VehicleTracker.VehicleData.Domain.Interfaces;

namespace VehicleTracker.VehicleData.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler _bus;

        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _bus = bus;
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return _customerRepository.GetAll().ProjectTo<CustomerViewModel>(_mapper.ConfigurationProvider);
        }

        public CustomerViewModel GetById(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
        }

        public void AddNewCustomer(CustomerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<AddNewCustomerCommand>(customerViewModel);
            _bus.SendCommand(registerCommand);
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            _bus.SendCommand(removeCommand);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
