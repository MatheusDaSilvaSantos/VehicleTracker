using System;
using System.Collections.Generic;
using VehicleTracker.VehicleData.Application.ViewModels;

namespace VehicleTracker.VehicleData.Application.Interfaces
{
    public interface IVehicleAppService : IDisposable
    {
        void Register(VehicleViewModel vehicleViewModel);
        IEnumerable<VehicleViewModel> GetAll();
        VehicleViewModel GetById(Guid id);
        VehicleViewModel GetByVehicleId(string vehicleId);
        void Update(VehicleViewModel customerViewModel);
        void Remove(Guid id);

    }
}