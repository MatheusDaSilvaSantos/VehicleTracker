using System.Collections.Generic;
using System.Threading;
using VehicleTracker.TrackerEngine.Domain.Models;

namespace VehicleTracker.TrackerEngine.Domain.StatusService
{
    public interface IVehiclesConnectionStatusService
    {
        IEnumerable<VehicleConnectionStatusModel> GetVehiclesConnectionStatus(CancellationToken cancellationToken = default(CancellationToken));
    }
}