namespace Writer.Domain.Aggregates;

public interface IAggregateLoader<TAggregate>
     where TAggregate : IAggregateRoot
{
    Task<TAggregate?> LoadAsync(Guid id);
}

