using Writer.Domain;
using Writer.Domain.Aggregates;
using Writer.Domain.Repositories;

namespace Writer.Infrastructure.Repositories;

internal class ProductRepository : IProductRepository
{
    public Task<ProductAggregate> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync(ProductAggregate product, IMetadata metadata)
    {
        throw new NotImplementedException();
    }
}
