using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using VehicleTracker.TrackerEngine.Domain.Events;
using VehicleTracker.TrackerEngine.Domain.Interfaces;
using VehicleTracker.TrackerEngine.Domain.Models;
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
            // get all data from azure  table and proses the status logic then push all cars data with status via signalR

            var response = new List<VehicleConnectionStatusResponse>();


            var allVehiclesPingData = _vehiclesConnectionStatusRepository.GetAllAsync().Result;
            if (allVehiclesPingData != null)
            {
                foreach (var pingItem in allVehiclesPingData)
                {
                    var status = GetPingStatus(pingItem.PingTime);

                    response.Add(new VehicleConnectionStatusResponse
                    {
                        VehicleId = pingItem.VehicleId,
                        Status = GetPingStatus(pingItem.PingTime)
                    });
                }
            }

            return _hubContext.Clients.All.SendAsync("vehiclesPinged", response, cancellationToken);
            //return Task.CompletedTask;
        }

        private bool GetPingStatus(string pingTimeString)
        {
            DateTime.TryParse(pingTimeString, out var pingTime);
            var status = pingTime >= DateTime.UtcNow.AddMinutes(-1) && pingTime <= DateTime.UtcNow;
            return status;
        }
    }
}