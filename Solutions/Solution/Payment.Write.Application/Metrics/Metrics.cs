using System.Diagnostics.Metrics;

namespace Payment.Write.Application.Metrics
{
    public sealed class Metrics : IMetrics
    {
        private static Counter<int> _paymentCreatedCounter = new Meter("Payment").CreateCounter<int>("payment-created", "Payment");

        public void PaymentCreated()
        {
            _paymentCreatedCounter.Add(1);
        }
    }
}
