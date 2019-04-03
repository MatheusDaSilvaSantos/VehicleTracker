using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleTracker.PingReceiver.Application.ViewModels;

namespace VehicleTracker.PingReceiver.Application.Interfaces
{
    public interface IPingAppService 
    {
        Task SendPingMessageAsync (PingViewModel pingViewModel);

    }

}
