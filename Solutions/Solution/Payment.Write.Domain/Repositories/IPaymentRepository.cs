using Payment.Write.Domain.Entities;

namespace Payment.Write.Domain.Repositories
{
    public interface IPaymentRepository
    {

        public Task<PaymentAggregate> GetAsync(Guid id, CancellationToken cancellationToken = default);
        public Task StoreAsyc(PaymentAggregate aggregate, CancellationToken cancellationToken = default);
    }
}
