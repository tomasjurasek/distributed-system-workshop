using Payment.Write.Domain.Events;

namespace Payment.Write.Domain.Entities
{
    public class PaymentAggregate : Aggregate
    {
        public PaymentAggregate(decimal amount, string currency) : base()
        {
            Apply(new PaymentCreated
            {
                CreatedAt = DateTime.UtcNow,
                Amount = amount,
                Currency = currency,
                AggregateId = Guid.NewGuid(),
                Id = Guid.NewGuid()
            });
        }

        public PaymentAggregate(IList<IEvent> events) : base(events) { }

        private void On(PaymentCreated @event)
        {
            Id = @event.AggregateId;
            CreatedAt = @event.CreatedAt;
        }
    }
}
