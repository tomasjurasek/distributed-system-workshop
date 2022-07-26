using Writer.Domain.Events;
using Writer.Domain.Exceptions;

namespace Writer.Domain.Aggregates;

public class ProductAggregate : AggregateRoot
{
    public string Code { get; private set; }
    public string Desription { get; private set; }
    public int Quantity { get; private set; }
    public string ImageUrl { get; private set; }
    public ProductStatus Status  { get; private set; }

    public static ProductAggregate Create(string code, string description, string imageUrl, int quantity) => new ProductAggregate(code, description, imageUrl, quantity);

    internal ProductAggregate(string code, string description, string imageUrl, int quantity)
    {
        if (quantity < 0)
        {
            throw new InvalidBusinessValidationException(); // TODO
        }

        Publish(new ProductCreatedEventEnvelope
        {
            Type = EventType.ProductCreated,
            CreatedAt = DateTime.UtcNow,
            CorrelationId = Guid.NewGuid(),
            Version = 1,
            Event = new ProductCreatedEvent
            {
                Code = code,
                Description = description,
                ImageUrl = imageUrl,
                Quantity = quantity,
            }
        });
    }

    protected override void Publish(IEventEnvelope<IEvent> envelope, bool isHistory = false)
    {
        switch (envelope)
        {
            case ProductCreatedEventEnvelope e: Apply(e); break;
            default:
                throw new InvalidOperationException();
        }

        if (!isHistory)
        {
            _uncommitedEvents.Add(envelope);
        }

        Version += 1;
    }

    private void Apply(ProductCreatedEventEnvelope envelope)
    {
        Code = envelope.Event.Code;
        Desription = envelope.Event.Description;
        Quantity = envelope.Event.Quantity;
        ImageUrl = envelope.Event.ImageUrl;
    }
}
