using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using Order.Contracts.Orders.Events;
using Order.Read.Application.DTO;
using System.Text.Json;

namespace Order.Read.Handlers
{
    public class OrderCanceledHandler : IConsumer<OrderCanceled>
    {

        private readonly IDistributedCache _cache;

        public OrderCanceledHandler(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task Consume(ConsumeContext<OrderCanceled> context)
        {
            var order = JsonSerializer.Deserialize<OrderDTO>(await _cache.GetStringAsync(context.Message.Id.ToString()));
            await _cache.SetStringAsync(context.Message.Id.ToString(), JsonSerializer.Serialize(order));
        }
    }
}
