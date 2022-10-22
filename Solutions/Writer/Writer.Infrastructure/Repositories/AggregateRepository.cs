using Writer.Domain;
using Writer.Domain.Aggregates;
using Writer.Domain.Aggregates.Root;

namespace Writer.Infrastructure.Repositories
{
    internal class AggregateRepository<TAggregate> : IAggregateRepository<TAggregate>
        where TAggregate : class, IAggregateRoot
    {
        public async Task<TAggregate> GetAsync(Guid id)
        {
            return null;
        }

        public async Task SaveAsync(TAggregate aggregate, IContext context)
        {
            
        }
    }
}
