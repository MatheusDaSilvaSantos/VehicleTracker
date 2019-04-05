using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.TrackerEngine.Domain.Interfaces;
using VehicleTracker.TrackerEngine.Domain.Models;

namespace VehicleTracker.TrackerEngine.Infra.Data.Repository
{
    public class VehiclesConnectionStatusRepository : TableRepository<VehiclesConnectionStatus>, IVehiclesConnectionStatusRepository
    {
        public VehiclesConnectionStatusRepository(IGetCloudTable tables) : base(tables)
        {
        }
    }

}