namespace Writer.Domain.Events;

public record PaymentRefunded : EventRoot
{
    public Guid Id { get; set; }

    public override EventType Type => throw new NotImplementedException();
}

