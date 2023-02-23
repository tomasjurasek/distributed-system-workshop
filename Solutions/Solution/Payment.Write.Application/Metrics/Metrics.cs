using System.Diagnostics.Metrics;

namespace Order.Write.Application.Metrics
{
    public sealed class Metrics : IMetrics
    {
        private static Counter<int> _OrderCreatedCounter = new Meter("Order").CreateCounter<int>("Order-created", "Order");

        public void OrderCreated()
        {
            _OrderCreatedCounter.Add(1);
        }
    }
}
