namespace Writer.Domain.Events;

public enum EventType
{
    Unknown = 0,
    OrderCreated = 1,
    OrderCanceled = 2,
    PaymentCreated = 3,
    PaymentRefunded = 4
}

