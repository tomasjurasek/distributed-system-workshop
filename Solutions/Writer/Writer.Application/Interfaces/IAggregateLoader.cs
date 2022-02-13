using Writer.Domain.Aggregates;
namespace Writer.Application.Interfaces;

public interface IAggregateLoader<TAggregate>
     where TAggregate : IAggregateRoot
{
    Task<TAggregate?> LoadAsync(Guid id);
}

