namespace Writer.Domain.Events;

public record ProductCodeChangedEvent : IEvent
{
    public Guid Id { get; init; }
    public string Code { get; init; }
}