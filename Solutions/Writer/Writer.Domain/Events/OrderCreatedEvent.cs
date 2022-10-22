namespace Writer.Domain.Events;

public record OrderCreatedEvent : IEvent
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }

}