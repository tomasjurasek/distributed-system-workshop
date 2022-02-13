using Writer.Application.Interfaces;
using Writer.Domain.Events;

namespace Writer.Infrastructure.Storages;

internal class EventStore : IEventStore
{
    public Task StoreAsync(ICollection<IEvent> events)
    {
        throw new NotImplementedException();
    }
}

