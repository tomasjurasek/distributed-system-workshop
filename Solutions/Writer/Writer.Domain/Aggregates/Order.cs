using Writer.Domain.Events;
namespace Writer.Domain.Aggregates;

public class Order : AggregateRoot
{
    public string Product { get; private set; }
    public Contact Contact { get; private set; }

    protected override void Publish(IEvent @event, bool isHistory = false)
    {
        throw new NotImplementedException();
    }

    private void Apply(OrderCreated @event)
    {
    }

    private void Apply(OrderCanceled @event)
    {
    }
}

