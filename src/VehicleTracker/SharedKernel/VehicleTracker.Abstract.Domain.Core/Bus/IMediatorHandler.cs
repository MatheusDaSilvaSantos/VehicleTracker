using System.Threading.Tasks;
using VehicleTracker.Abstract.Domain.Core.Commands;
using VehicleTracker.Abstract.Domain.Core.Events;
using VehicleTracker.Abstract.Domain.Core.Queries;

namespace VehicleTracker.Abstract.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<TResponse>(TResponse command) where TResponse : Command;
        Task RaiseEvent<TResponse>(TResponse @event) where TResponse : Event;
        Task<TResponse> GetQuery<TResponse, TQuery>(TQuery query) where TQuery : Query<TResponse>;
    }
}
