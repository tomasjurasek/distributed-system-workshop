using Writer.Domain.Events;
using Writer.Domain.Exceptions;

namespace Writer.Domain.Aggregates;

public class Payment : AggregateRoot
{
 
    public string Currency { get; private set; }

    public decimal Amount { get; private set; }

    public PaymentStatus Status { get; private set; }

    public DateTime? RefundedAt { get; private set; }

    public static Payment Create(string currency, decimal amout) => new Payment(currency, amout);

    internal Payment(string currency, decimal amount)
    {
        if (amount < 0)
        {
            throw new InvalidBusinessValidationException(); // TODO
        }

        Amount = amount;
        Currency = currency;
    }

    public void Refund()
    {

        if (Status != PaymentStatus.Paid)
        {
            throw new InvalidBusinessValidationException(); // TODO
        }

        Status = PaymentStatus.Refunded;

        Publish(new PaymentRefunded
        {
            CreatedAt = DateTime.UtcNow,
            Id = Guid.NewGuid()
        });
    }

    protected override void Publish(IEvent @event, bool isHistory = false)
    {
        switch (@event)
        {
            case PaymentCreated e: Apply(e); break;
            case PaymentRefunded e: Apply(e); break;
            default:
                throw new InvalidOperationException();
        }

        if(!isHistory)
        {
            _uncommitedEvents.Add(@event);
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

