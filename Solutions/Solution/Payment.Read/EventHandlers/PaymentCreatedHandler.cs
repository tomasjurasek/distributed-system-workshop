using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using Payment.Contracts.Events;
using Payment.Read.Application.DTO;
using System.Text.Json;

namespace Payment.Read.Handlers
{
    public class PaymentCreatedHandler : IConsumer<PaymentCreated>
    {

        private readonly IDistributedCache _cache;

        public PaymentCreatedHandler(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task Consume(ConsumeContext<PaymentCreated> context)
        {
            var payment = new PaymentDTO
            {
                Id = context.Message.AggregateId,
                Amount = context.Message.Amount,
                Currency = context.Message.Currency
            };

            await _cache.SetStringAsync(context.Message.Id.ToString(), JsonSerializer.Serialize(payment));
           
        }
    }
}
