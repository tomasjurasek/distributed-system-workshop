using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Order.Read.Application.DTO;
using System.Text.Json;

namespace Order.Read.Application.Queries
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDTO>
    {
        private readonly IDistributedCache _cache;

        public GetOrderQueryHandler(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<OrderDTO> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var jsonData = await _cache.GetAsync(request.Id.ToString());

            return JsonSerializer.Deserialize<OrderDTO>(jsonData);
        }
    }
}
