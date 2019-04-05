using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.TrackerEngine.Application.EventSourcedNormalizers;
using VehicleTracker.TrackerEngine.Application.Interfaces;
using VehicleTracker.TrackerEngine.Application.ViewModels;
using VehicleTracker.TrackerEngine.Domain.Commands;
using VehicleTracker.TrackerEngine.Infra.Data.Repository;

namespace VehicleTracker.TrackerEngine.Application.Services
{
    public class VehiclePingAppService : IVehiclePingAppService
    {
        private readonly IMapper _mapper;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _bus;

        public VehiclePingAppService(IMapper mapper,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }


        public void ReceivePingMessage(VehiclePingViewModel pingViewModel)
        {
            var registerCommand = _mapper.Map<VehiclePingCommand>(pingViewModel);
             _bus.SendCommand(registerCommand);

        }

        public IList<VehiclePingHistoryData> GetAllHistory(Guid id)
        {
            return VehiclePingHistory.ToJavaScriptVehiclePingHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
