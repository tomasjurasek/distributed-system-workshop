using Writer.Domain.Aggregates.Root;

namespace Writer.Domain.Aggregates
{
    public interface IAggregateRepository<TAggregate> where TAggregate: class, IAggregateRoot
    {
        Task SaveAsync(TAggregate aggregate, IContext context);
        Task<TAggregate> GetAsync(Guid id);
    }
}
