namespace Writer.Domain.Events;

public record PaymentCreated : IEvent
{
    public Guid Id { get; init; }
    public string Currency { get; init; }
    public decimal Amount { get; init; }
    public DateTime CreatedAt { get; set; }
}

