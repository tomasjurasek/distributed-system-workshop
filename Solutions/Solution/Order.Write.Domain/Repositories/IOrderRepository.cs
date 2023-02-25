using Order.Write.Domain.Entities;

namespace Order.Write.Domain.Repositories
{
    public interface IOrderRepository
    {
        public Task<OrderAggregate> GetAsync(Guid id, CancellationToken cancellationToken = default);
        public Task StoreAsyc(OrderAggregate aggregate, CancellationToken cancellationToken = default);
    }
}
