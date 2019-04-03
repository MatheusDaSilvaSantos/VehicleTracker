using System;
using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.VehicleData.Domain.Models;

namespace VehicleTracker.VehicleData.Domain.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Vehicle GetByVehicleId(string vehicleId);
    }
}