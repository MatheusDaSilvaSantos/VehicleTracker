using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleTracker.Abstract.Domain.Core.Events;

namespace VehicleTracker.PingReceiver.Domain.Interfaces
{
    public interface ISendMessagesService
    {
        Task SendAsync<T>(T data, string messageid);
        Task SendMessageAsync<T>(T message) where T : Message;
    }
}
