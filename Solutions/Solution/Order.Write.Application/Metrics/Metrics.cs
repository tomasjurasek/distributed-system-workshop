using System.Diagnostics.Metrics;

namespace Order.Write.Application.Metrics
{
    public sealed class Metrics : IMetrics
    {
        private static Counter<int> _OrderCreatedCounter = new Meter("Order").CreateCounter<int>("order-created", "Order");
        private static Counter<int> _OrderCanceledCounter = new Meter("Order").CreateCounter<int>("order-canceled", "Order");

        public void OrderCreated()
        {
            _OrderCreatedCounter.Add(1);
        }

        public void OrderCanceled()
        {
            _OrderCanceledCounter.Add(1);
        }
    }
}
