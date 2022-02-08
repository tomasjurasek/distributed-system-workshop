using Writer.Domain.Events;
namespace Writer.Domain.Aggregates;

public class Payment : AggregateRoot
{
    public string Currency { get; private set; }

    public decimal Amount { get; private set; }

    public PaymentStatus Status { get; private set; }

    public DateTime? RefundedAt { get; private set; }

    public void Apply(IEvent @event)
    {
        switch (@event)
        {
            case PaymentCreated e: Apply(e); break;
            case PaymentRefunded e: Apply(e); break;
            default:
                throw new InvalidOperationException();
        }

        Version += 1;
    }

    private void Apply(PaymentCreated @event)
    {
        Id = @event.Id;
        Currency = @event.Currency;
        Amount = @event.Amount;
        CreatedAt = @event.CreatedAt;
        Status = PaymentStatus.Paid;
    }

    private void Apply(PaymentRefunded @event)
    {
        Status = PaymentStatus.Refunded;
        RefundedAt = @event.CreatedAt;
    }
}

