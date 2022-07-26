using Writer.Domain.Events;
namespace Writer.Domain;
public record EventEnvelope<TEvent> : IEventEnvelope<TEvent> where TEvent : IEvent
{
    public DateTime CreatedAt { get; init; }

    public EventType Type { get; init; }

    public Guid CorrelationId { get; init; }

    public TEvent Event { get; init; }

    public int Version { get; init; }
}
