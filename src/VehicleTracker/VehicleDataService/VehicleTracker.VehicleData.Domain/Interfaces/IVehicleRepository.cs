using System;
using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.VehicleData.Domain.Models;

namespace VehicleTracker.VehicleData.Domain.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Customer GetByVehicleId(Guid vehicleId);
    }
}