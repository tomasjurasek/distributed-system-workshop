namespace Writer.Domain.Events;

public record PaymentRefunded : IEvent
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
}

