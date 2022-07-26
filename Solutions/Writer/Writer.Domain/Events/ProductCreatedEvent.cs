using Writer.Domain.Events;
namespace Writer.Domain.Events;

public record ProductCreatedEvent : IEvent
{
    public string Code { get; init; }
    public string Description { get; init; }
    public int Quantity { get; init; }
    public string ImageUrl { get; init; }
}
