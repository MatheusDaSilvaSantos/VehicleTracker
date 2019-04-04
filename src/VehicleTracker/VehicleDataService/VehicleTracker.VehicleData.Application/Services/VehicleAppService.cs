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
    public class VehicleAppService : IVehicleAppService
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMediatorHandler _bus;

        public VehicleAppService(IMapper mapper,
            IVehicleRepository vehicleRepository,
            IMediatorHandler bus)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _bus = bus;
        }

        public IEnumerable<VehicleViewModel> GetAll()
        {
            return _vehicleRepository.GetAll().ProjectTo<VehicleViewModel>(_mapper.ConfigurationProvider);
        }

        public VehicleViewModel GetById(Guid id)
        {
            return _mapper.Map<VehicleViewModel>(_vehicleRepository.GetById(id));
        }

        public VehicleViewModel GetByVehicleId(string vehicleId)
        {
            return _mapper.Map<VehicleViewModel>(_vehicleRepository.GetByVehicleId(vehicleId));
        }

        public void AddNewVehicle(VehicleViewModel vehicleViewModel)
        {
            var registerCommand = _mapper.Map<AddNewVehicleCommand>(vehicleViewModel);
            _bus.SendCommand(registerCommand);
        }

        public void Update(VehicleViewModel vehicleViewModel)
        {
            var updateCommand = _mapper.Map<UpdateVehicleCommand>(vehicleViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveVehicleCommand(id);
            _bus.SendCommand(removeCommand);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}