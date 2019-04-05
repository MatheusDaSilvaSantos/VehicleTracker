using System;
using System.Collections.Generic;
using VehicleTracker.Abstract.Domain.Core.Events;

namespace VehicleTracker.Abstract.Domain.Core.Interfaces
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}