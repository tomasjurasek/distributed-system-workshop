using Order.Contracts.Events;

namespace Order.Write.Domain.Entities
{
    public interface IAggregate
    {
        Guid Id { get; }

        DateTime CreatedAt { get; }

        int Version { get; }

        IEnumerable<IEvent> UncommitedEvents { get; }
    }
}
