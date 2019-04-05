using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using VehicleTracker.TrackerEngine.Domain.Events;
using VehicleTracker.TrackerEngine.Domain.Interfaces;
using VehicleTracker.TrackerEngine.Domain.RealTime;

namespace VehicleTracker.TrackerEngine.Domain.EventHandlers
{
    public class VehiclePingEventHandler :
        INotificationHandler<VehiclePingedEvent>
    {
        private readonly IVehiclesConnectionStatusRepository _vehiclesConnectionStatusRepository;
        private readonly IHubContext<PingingStatusEventsClientHub> _hubContext;
        public VehiclePingEventHandler(IVehiclesConnectionStatusRepository vehiclesConnectionStatusRepository, IHubContext<PingingStatusEventsClientHub> hubContext)
        {
            _vehiclesConnectionStatusRepository = vehiclesConnectionStatusRepository;
            _hubContext = hubContext;
        }

        public Task Handle(VehiclePingedEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification 
            // get all data from azure  table and proses the statsue logic then push all cars data with statuse via signalR
            var allVehiclesPingData = _vehiclesConnectionStatusRepository.GetAllAsync().Result;

            //return _hubContext.Clients.All.SendAsync("vehiclesPinged", @event, cancellationToken);
            return Task.CompletedTask;
        }
    }
}