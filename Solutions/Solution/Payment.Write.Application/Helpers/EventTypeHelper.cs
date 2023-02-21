using Payment.Contracts.Events;

namespace Payment.Write.Application.Helpers
{
    public static class EventTypeHelper
    {
        public static Type GetType(string type) => type switch
        {
            nameof(PaymentCreated) => typeof(PaymentCreated)
        };
    }
}
