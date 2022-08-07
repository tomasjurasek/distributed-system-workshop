using Writer.Domain.Aggregates;

namespace Writer.Domain.Repositories;

public interface IProductRepository
{
    Task SaveAsync(ProductAggregate product, IMetadata metadata);
    Task<ProductAggregate> GetAsync(Guid id);
}
