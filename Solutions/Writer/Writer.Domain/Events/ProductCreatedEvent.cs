namespace Writer.Domain.Events;

public record ProductCreatedEvent : IEvent
{
    public Guid Id { get; init; }
    public string Code { get; init; }
    public string Description { get; init; }
    public int Quantity { get; init; }
    public string ImageUrl { get; init; }
    public DateTime CreatedAt { get; init; }
}