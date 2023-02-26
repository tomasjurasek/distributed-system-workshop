using Order.Contracts.Events;

namespace Order.Contracts.Orders.Events
{
    public record OrderCreated : Event
    {
        public Customer Customer { get; init; }

        public Address DeliveryAddress { get; init; }

        public IReadOnlyCollection<Product> Products { get; init; } = new List<Product>();

        public string Currency { get; init; }

        public OrderStatus Status { get; init; }
    }
}
