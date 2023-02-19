using Payment.Write.Domain.Events;

namespace Payment.Write.Domain.Entities
{
    public class PaymentAggregate : Aggregate
    {

        public static PaymentAggregate Create() => new PaymentAggregate();
        public static PaymentAggregate LoadHistory(IList<IEvent> events) => new PaymentAggregate(events);


        internal PaymentAggregate(IList<IEvent> events = null)
        {

            if(events is null)
            {
                Apply(new PaymentCreated
                {
                    Id = Guid.NewGuid(),
                    AggregateId = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                }, false);
            }

            else
            {
                base.LoadHistory(events);
            }
            
        }

        protected override void Apply(IEvent @event, bool isHistory = false)
        {
            switch (@event)
            {
                case PaymentCreated e: Apply(e); break;
                default:
                    throw new InvalidOperationException();
            }

            if (!isHistory)
            {
                _uncommitedEvents.Add(@event);
            }

            Version += 1;
        }

        private void Apply(PaymentCreated @event)
        {
            Id = @event.AggregateId;
            CreatedAt = @event.CreatedAt;
        }
    }
}
