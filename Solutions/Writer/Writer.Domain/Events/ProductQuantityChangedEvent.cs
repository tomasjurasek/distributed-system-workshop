namespace Writer.Domain.Events;

public record ProductQuantityChangedEvent : IEvent
{
    public Guid Id { get; init; }
    public int Quantity { get; init; }
}
