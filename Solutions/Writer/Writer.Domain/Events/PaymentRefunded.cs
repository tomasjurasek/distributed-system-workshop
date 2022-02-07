namespace Writer.Domain.Events;

public record PaymentRefunded : EventRoot
{
    public Guid Id { get; set; }
}

