using Writer.Domain.Events;

namespace Writer.Domain.Aggregates;

public abstract class AggregateRoot : IAggregateRoot
{
    public Guid Id { get; protected set; }

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

public interface IAggregateRoot
{
    public Guid Id { get; }

    public int Version { get; }

    public DateTime CreatedAt { get; }

    public IEnumerable<IEvent> UncommitedEvents { get; }

    public void LoadFromHistory(ICollection<IEvent> events);
}

