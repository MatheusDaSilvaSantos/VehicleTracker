using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleTracker.TrackerEngine.Application.EventSourcedNormalizers;
using VehicleTracker.TrackerEngine.Application.ViewModels;

namespace VehicleTracker.TrackerEngine.Application.Interfaces
{
    public interface IVehiclePingAppService : IDisposable
    {
        void ReceivePingMessage(VehiclePingViewModel pingViewModel);
        IList<VehiclePingHistoryData> GetAllHistory(Guid id);
    }
}
