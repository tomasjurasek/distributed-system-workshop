using Writer.Domain.Events;
namespace Writer.Application.Interfaces;

public interface IEventStore
{
    Task StoreAsync(ICollection<IEvent> events);
}

