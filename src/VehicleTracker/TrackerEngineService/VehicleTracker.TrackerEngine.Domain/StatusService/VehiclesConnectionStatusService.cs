using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.SignalR;
using VehicleTracker.TrackerEngine.Domain.Interfaces;
using VehicleTracker.TrackerEngine.Domain.Models;
using VehicleTracker.TrackerEngine.Domain.RealTime;

namespace VehicleTracker.TrackerEngine.Domain.StatusService
{
    public class VehiclesConnectionStatusService : IVehiclesConnectionStatusService
    {
        private readonly IVehiclesConnectionStatusRepository _vehiclesConnectionStatusRepository;
        private readonly IHubContext<PingingStatusEventsClientHub> _hubContext;
        public VehiclesConnectionStatusService(IVehiclesConnectionStatusRepository vehiclesConnectionStatusRepository, IHubContext<PingingStatusEventsClientHub> hubContext)
        {
            _vehiclesConnectionStatusRepository = vehiclesConnectionStatusRepository;
            _hubContext = hubContext;
        }

        public IEnumerable<VehicleConnectionStatusModel> GetVehiclesConnectionStatus(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = new List<VehicleConnectionStatusModel>();


            var allVehiclesPingData = _vehiclesConnectionStatusRepository.GetAllAsync().Result;
            if (allVehiclesPingData != null)
            {
                foreach (var pingItem in allVehiclesPingData)
                {
                    var status = GetPingStatus(pingItem.PingTime);

                    response.Add(new VehicleConnectionStatusModel
                    {
                        VehicleId = pingItem.VehicleId,
                        Status = GetPingStatus(pingItem.PingTime)
                    });
                }
            }

            _hubContext.Clients.All.SendAsync("vehiclesPinged", response, cancellationToken);
            return response;
        }

        private bool GetPingStatus(string pingTimeString)
        {
            DateTime.TryParse(pingTimeString, out var pingTime);
            var status = pingTime >= DateTime.UtcNow.AddMinutes(-1) && pingTime <= DateTime.UtcNow;
            return status;
        }
    }
}