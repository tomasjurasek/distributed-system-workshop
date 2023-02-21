using Payment.Contracts.Events;

namespace Payment.Write.Domain.Entities
{
    public class PaymentAggregate : Aggregate
    {
        public PaymentAggregate(Guid orderId, decimal amount, string currency) : base()
        {
            Apply(new PaymentCreated
            {
                CreatedAt = DateTime.UtcNow,
                Amount = amount,
                OrderId = orderId,
                Status = PaymentStatus.Waiting,
                Currency = currency,
                AggregateId = Guid.NewGuid(),
                Id = Guid.NewGuid()
            });
        }

        public PaymentAggregate(IList<IEvent> events) : base(events) { }

        public PaymentStatus Status { get; private set; }
        public Guid OrderId { get; private set; }

        private void On(PaymentCreated @event)
        {
            Id = @event.AggregateId;
            OrderId = @event.OrderId;
            Status = @event.Status;
            CreatedAt = @event.CreatedAt;
        }
    }
}
