using Writer.Domain.Events;

namespace Writer.Domain.Aggregates.Root;

public interface IAggregateRoot
{
    Guid Id { get; }

    DateTime CreatedAt { get; }

    int Version { get; }

    IEnumerable<IEvent> UncommitedEvents { get; }

    void LoadFromHistory(ICollection<IEvent> events);
}

