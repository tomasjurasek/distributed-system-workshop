using Writer.Domain.Events;
namespace Writer.Domain.Aggregates;

public class Order : AggregateRoot
{
    public string Product { get; private set; }
    public Contact Contact { get; private set; }

    public void Apply(IEvent @event)
    {
    }

    private void Apply(OrderCreated @event)
    {
    }

    private void Apply(OrderCanceled @event)
    {
    }
}

