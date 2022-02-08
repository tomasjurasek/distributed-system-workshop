namespace Writer.Domain.Events;

public abstract record EventRoot : IEvent
{
    public DateTime CreatedAt { get; init; }

    public abstract EventType Type { get; }

    public Guid CorrelationId { get; init; }
}

public interface IEvent
{
    public DateTime CreatedAt { get; init; }

    public abstract EventType Type { get; }

    public Guid CorrelationId { get; init; }
}

