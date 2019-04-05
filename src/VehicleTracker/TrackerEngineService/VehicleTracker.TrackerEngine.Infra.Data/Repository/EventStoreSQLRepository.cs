using System;
using System.Collections.Generic;
using System.Linq;
using VehicleTracker.Abstract.Domain.Core.Events;
using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.TrackerEngine.Infra.Data.Context;

namespace VehicleTracker.TrackerEngine.Infra.Data.Repository
{
    public class EventStoreSqlRepository : IEventStoreRepository
    {
        private readonly EventStoreSqlContext _context;

        public EventStoreSqlRepository(EventStoreSqlContext context)
        {
            _context = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            return (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}