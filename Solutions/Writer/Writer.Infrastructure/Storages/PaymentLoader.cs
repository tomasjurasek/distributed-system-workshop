using Writer.Application.Interfaces;
using Writer.Domain.Aggregates;
namespace Writer.Infrastructure.Storages;

internal class PaymentLoader : IAggregateLoader<Payment>
{
    public Task<Payment?> LoadAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}

