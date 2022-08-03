using Dawn;
using Writer.Domain.Aggregates.Root;
using Writer.Domain.Events;

namespace Writer.Domain.Aggregates;

public class ProductAggregate : AggregateRoot
{
    public string Code { get; private set; }
    public string Desription { get; private set; }
    public int Quantity { get; private set; }
    public string ImageUrl { get; private set; }
    public ProductStatus Status { get; private set; }

    internal ProductAggregate(string code, string description, string imageUrl, int quantity, DateTime createdAt)
    {
        Guard.Argument(quantity, nameof(quantity)).NotNegative();
        Guard.Argument(code, nameof(code)).NotNull().NotEmpty();
        Guard.Argument(description, nameof(description)).NotNull().NotEmpty();

        var @event = new ProductCreatedEvent
        {
            CreatedAt = createdAt,
            Code = code,
            Description = description,
            ImageUrl = imageUrl,
            Quantity = quantity,
        };

        Publish(@event);
    }

    protected override void Publish(IEvent @event, bool isHistory = false)
    {
        switch (@event)
        {
            case ProductCreatedEvent e: Apply(e); break;
            default:
                throw new InvalidOperationException();
        }

        if (!isHistory)
        {
            _uncommitedEvents.Add(@event);
        }

        Version += 1;
    }

    private void Apply(ProductCreatedEvent @event)
    {
        CreatedAt = @event.CreatedAt;
        Code = @event.Code;
        Desription = @event.Description;
        Quantity = @event.Quantity;
        ImageUrl = @event.ImageUrl;
    }
}
