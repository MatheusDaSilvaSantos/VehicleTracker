using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.TrackerEngine.Domain.Models;

namespace VehicleTracker.TrackerEngine.Domain.Interfaces
{
    public interface IVehiclesConnectionStatusRepository : ITableRepository<VehiclesConnectionStatus>
    {

    }
}