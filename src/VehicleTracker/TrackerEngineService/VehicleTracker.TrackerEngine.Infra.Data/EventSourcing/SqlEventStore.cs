using Newtonsoft.Json;
using VehicleTracker.Abstract.Domain.Core.Events;
using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.TrackerEngine.Infra.Data.Repository;

namespace VehicleTracker.TrackerEngine.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}