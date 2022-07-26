namespace Writer.Domain.Aggregates;

public interface IAggregateStore<TAggregate>
   where TAggregate : IAggregateRoot
{
    Task StoreAsync(TAggregate aggregate);
}
