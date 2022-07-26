using Writer.Domain.Events;

namespace Writer.Domain.Aggregates;

public abstract class AggregateRoot : IAggregateRoot
{
    public Guid Id { get; protected set; }
    public int Version { get; protected set; }

    public DateTime CreatedAt { get; protected set; }

    protected ICollection<IEventEnvelope<IEvent>> _uncommitedEvents = Array.Empty<IEventEnvelope<IEvent>>();

    public IEnumerable<IEventEnvelope<IEvent>> UncommitedEvents => _uncommitedEvents;

    protected abstract void Publish(IEventEnvelope<IEvent> @event, bool isHistory = false);

    public void LoadFromHistory(ICollection<IEventEnvelope<IEvent>> events)
    {
        foreach (var @event in events)
        {
            Publish(@event, true);
        }
    }
}

public interface IAggregateRoot
{
    Guid Id { get; }

    DateTime CreatedAt { get; }

    int Version { get; }

    IEnumerable<IEventEnvelope<IEvent>> UncommitedEvents { get; }

    void LoadFromHistory(ICollection<IEventEnvelope<IEvent>> events);
}

