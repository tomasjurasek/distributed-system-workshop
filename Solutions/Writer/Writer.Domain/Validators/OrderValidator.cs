using Writer.Domain.Aggregates;
namespace Writer.Domain.Validators;

public class OrderValidator<TAggregate> where TAggregate : IAggregateRoot
{
    public IEnumerable<string> GetValidationErrors<TAggregate, CreateOrder>(TAggregate aggregate, CreateOrder command)
    {
        yield return string.Empty;
    }
}

