namespace Writer.Domain.Events;

public record PaymentCreated : EventRoot
{
    public Guid Id { get; init; }
    public string Currency { get; init; }
    public decimal Amount { get; init; }
    public string Type { get; init; }
}

