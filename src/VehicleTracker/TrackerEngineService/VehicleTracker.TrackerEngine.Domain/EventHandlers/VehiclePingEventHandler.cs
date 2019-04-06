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
using VehicleTracker.TrackerEngine.Domain.StatusService;

namespace VehicleTracker.TrackerEngine.Domain.EventHandlers
{
    public class VehiclePingEventHandler :
        INotificationHandler<VehiclePingedEvent>
    {
        private readonly IVehiclesConnectionStatusService _vehiclesConnectionStatusService;

        public VehiclePingEventHandler( IVehiclesConnectionStatusService vehiclesConnectionStatusService)
        {
            _vehiclesConnectionStatusService = vehiclesConnectionStatusService;

        }

        public Task Handle(VehiclePingedEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification 
            // get all data from azure  table and proses the status logic then push all cars data with status via signalR
            _vehiclesConnectionStatusService.GetVehiclesConnectionStatus(cancellationToken);

            return Task.CompletedTask;
        }


    }


}