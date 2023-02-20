using Payment.Write.Domain.Events;

namespace Payment.Write.Domain.Entities
{
    public abstract class Aggregate : IAggregate
    {
        protected Aggregate(IEnumerable<IEvent> events)
        {
            foreach (var @event in events)
            {
                Mutate(@event);
                Version++;
            }
        }

        protected Aggregate() { }


        public Guid Id { get; protected set; }

        public int Version { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        protected ICollection<IEvent> _uncommitedEvents = new List<IEvent>();

        public IEnumerable<IEvent> UncommitedEvents => _uncommitedEvents;

        protected void Apply(IEvent @event)
        {
            Mutate(@event);
            _uncommitedEvents.Add(@event);
            Version++;
        }

        private void Mutate(IEvent @event)
        {
            ((dynamic)this).On((dynamic)@event);
        }
    }
}
