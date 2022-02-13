using Writer.Application.Interfaces;
using Writer.Domain.Aggregates;
namespace Writer.Infrastructure.Storages;

internal class OrderLoader : IAggregateLoader<Order>
{
    public Task<Order?> LoadAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}

