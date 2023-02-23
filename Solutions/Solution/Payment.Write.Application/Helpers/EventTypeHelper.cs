using Order.Contracts.Orders.Events;

namespace Order.Write.Application.Helpers
{
    public static class EventTypeHelper
    {
        public static Type GetType(string type) => type switch
        {
            nameof(OrderCreated) => typeof(OrderCreated)
        };
    }
}
