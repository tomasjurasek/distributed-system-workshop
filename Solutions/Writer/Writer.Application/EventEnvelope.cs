using Writer.Domain.Events;
namespace Writer.Application;

public record EventEnvelope
{
    public DateTime CreatedAt { get; init; }

    public EventType Type { get; init; }

    public Guid CorrelationId { get; init; }

    public IEvent Data { get; init; }
}

