using Payment.Write.Domain.Events;

namespace Payment.Write.Domain.Entities
{
    public abstract class Aggregate : IAggregate
    {
        public Guid Id { get; protected set; }

        public int Version { get; protected set; }

        public DateTime CreatedAt { get; protected set; }


        protected ICollection<IEvent> _uncommitedEvents = new List<IEvent>();

        public IEnumerable<IEvent> UncommitedEvents => _uncommitedEvents;

        protected abstract void Apply(IEvent @event, bool isHistory = false);

        protected void LoadHistory(IList<IEvent> events)
        {
            foreach (var @event in events)
            {
                Apply(@event, true);
            }
        }
    }
}
