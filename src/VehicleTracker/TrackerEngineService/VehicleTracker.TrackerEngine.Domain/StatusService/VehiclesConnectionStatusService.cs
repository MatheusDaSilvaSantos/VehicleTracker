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


            var allVehiclesPingData = _vehiclesConnectionStatusRepository.GetAll();
            if (allVehiclesPingData != null)
            {
                foreach (var pingItem in allVehiclesPingData)
                {
                    var status = GetPingStatus(pingItem.PingTime);

                    response.Add(new VehicleConnectionStatusModel
                    {
                        VehicleId = pingItem.VehicleId,
                        Status = status
                    });
                }
            }

            _hubContext.Clients.All.SendAsync("vehiclesPinged", response, cancellationToken);
            return response;
        }

        private bool GetPingStatus(string pingTimeString)
        {
            DateTime.TryParse(pingTimeString, out var pingTime);
            var totalMinutes = (DateTime.UtcNow - pingTime).TotalMinutes;
            var totalDays = (int)(DateTime.UtcNow - pingTime).TotalDays;

            bool status = totalMinutes >= 0 && totalMinutes <= 1 && totalDays == 0;
            return status;
        }
    }
}