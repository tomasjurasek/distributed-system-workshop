using Writer.Domain.Events;

namespace Writer.Domain.Aggregates.Root;

public abstract class AggregateRoot : IAggregateRoot
{
    public Guid Id { get; protected set; } // Do I need it?

    public int Version { get; protected set; }

    public DateTime CreatedAt { get; protected set; }

    protected ICollection<IEvent> _uncommitedEvents = Array.Empty<IEvent>();

    public IEnumerable<IEvent> UncommitedEvents => _uncommitedEvents;

    protected abstract void Publish(IEvent @event, bool isHistory = false);

    public void LoadFromHistory(ICollection<IEvent> events)
    {
        foreach (var @event in events)
        {
            Publish(@event, true);
        }
    }
}