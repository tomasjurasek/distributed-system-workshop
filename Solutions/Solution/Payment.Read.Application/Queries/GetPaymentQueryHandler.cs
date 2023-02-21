using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Payment.Read.Application.DTO;
using System.Text.Json;

namespace Payment.Read.Application.Queries
{
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, PaymentDTO>
    {
        private readonly IDistributedCache _cache;

        public GetPaymentQueryHandler(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<PaymentDTO> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            var jsonData = await _cache.GetAsync(request.Id.ToString());

            return JsonSerializer.Deserialize<PaymentDTO>(jsonData);
        }
    }
}
