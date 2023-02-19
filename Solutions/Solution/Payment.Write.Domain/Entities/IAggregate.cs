using Payment.Write.Domain.Events;

namespace Payment.Write.Domain.Entities
{
    public interface IAggregate
    {
        Guid Id { get; }

        DateTime CreatedAt { get; }

        int Version { get; }

        IEnumerable<IEvent> UncommitedEvents { get; }
    }
}
