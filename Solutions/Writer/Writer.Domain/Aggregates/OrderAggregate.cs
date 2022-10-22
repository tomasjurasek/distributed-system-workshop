using Writer.Domain.Aggregates.Root;
using Writer.Domain.Events;

namespace Writer.Domain.Aggregates;

public class OrderAggregate : AggregateRoot
{
    public Guid Id { get; private set; }

    internal OrderAggregate(Guid id, DateTime createdAt)
    {
        var @event = new OrderCreatedEvent
        {
            Id = id,
            CreatedAt = createdAt
        };

        Publish(@event);
    }

    protected override void Publish(IEvent @event, bool isHistory = false)
    {
        switch (@event)
        {
            case OrderCreatedEvent e: Apply(e); break;
            default:
                throw new InvalidOperationException();
        }

        if (!isHistory)
        {
            _uncommitedEvents.Add(@event);
        }

        Version += 1;
    }

    private void Apply(OrderCreatedEvent @event)
    {
        Id = @event.Id;
        CreatedAt = @event.CreatedAt;
    }
}
