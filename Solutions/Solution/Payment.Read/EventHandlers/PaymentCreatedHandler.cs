using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using Order.Contracts.Orders.Events;
using Order.Read.Application.DTO;
using System.Text.Json;

namespace Order.Read.Handlers
{
    public class OrderCreatedHandler : IConsumer<OrderCreated>
    {

        private readonly IDistributedCache _cache;

        public OrderCreatedHandler(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task Consume(ConsumeContext<OrderCreated> context)
        {
            var Order = new OrderDTO
            {
                Id = context.Message.AggregateId,
                Currency = context.Message.Currency
            };

            await _cache.SetStringAsync(context.Message.Id.ToString(), JsonSerializer.Serialize(Order));
           
        }
    }
}
