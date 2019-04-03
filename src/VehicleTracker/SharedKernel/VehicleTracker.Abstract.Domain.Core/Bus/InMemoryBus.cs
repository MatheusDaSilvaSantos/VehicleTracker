using System.Threading.Tasks;
using MediatR;
using VehicleTracker.Abstract.Domain.Core.Commands;
using VehicleTracker.Abstract.Domain.Core.Events;
using VehicleTracker.Abstract.Domain.Core.Queries;

namespace VehicleTracker.Abstract.Domain.Core.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            //if we using event sourcing then we should save the event in eventStore here.
            return _mediator.Publish(@event);
        }

        public Task<TResponse> GetQuery<TResponse, TQuery>(TQuery query) where TQuery : Query<TResponse>
        {
            return _mediator.Send(query);
        }
    }
}
