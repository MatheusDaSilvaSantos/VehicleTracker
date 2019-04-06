using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.TrackerEngine.Application.EventSourcedNormalizers;
using VehicleTracker.TrackerEngine.Application.Interfaces;
using VehicleTracker.TrackerEngine.Application.ViewModels;
using VehicleTracker.TrackerEngine.Domain.Commands;
using VehicleTracker.TrackerEngine.Domain.StatusService;
using VehicleTracker.TrackerEngine.Infra.Data.Repository;

namespace VehicleTracker.TrackerEngine.Application.Services
{
    public class VehiclePingAppService : IVehiclePingAppService
    {
        private readonly IMapper _mapper;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _bus;
        private readonly IVehiclesConnectionStatusService _connectionStatusService;


        public VehiclePingAppService(IMapper mapper,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository,
                                  IVehiclesConnectionStatusService connectionStatusService)
        {
            _mapper = mapper;
            _bus = bus;
            _eventStoreRepository = eventStoreRepository;
            _connectionStatusService = connectionStatusService;
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

        public IList<VehicleConnectionStatusViewModel> GetAllVehiclesConnectionStatus()
        {
            var statusList = _connectionStatusService.GetVehiclesConnectionStatus();
            var statusViewModelList = _mapper.Map<IList<VehicleConnectionStatusViewModel>>(statusList);
            return statusViewModelList;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
