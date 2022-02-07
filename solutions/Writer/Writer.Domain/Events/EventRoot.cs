namespace Writer.Domain.Events;

public abstract record EventRoot
{
    public DateTime CreatedAt { get; init; }
}

public interface IEvent
{
    public DateTime CreatedAt { get; }
}

