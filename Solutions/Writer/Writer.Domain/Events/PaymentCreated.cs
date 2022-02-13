namespace Writer.Domain.Events;

public record PaymentCreated : IEvent
{
    public Guid Id { get; init; }

    public Guid OrderId { get; set; }

    public string Currency { get; init; }

    public decimal Amount { get; init; }

    public DateTime CreatedAt { get; set; }
}

