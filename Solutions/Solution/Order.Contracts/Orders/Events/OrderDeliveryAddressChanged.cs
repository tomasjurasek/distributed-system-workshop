using Order.Contracts.Events;

namespace Order.Contracts.Orders.Events
{
    public record OrderDeliveryAddressChanged : Event
    {
        public Address Address { get; init; }
    }
}
