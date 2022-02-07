using Writer.Domain.Aggregates;
namespace Writer.Domain.Validators;

public class OrderValidator<TAggregate> where TAggregate : IAggregateRoot
{
    public ICollection<string> GetValidationErrors<TAggregate, CreateOrder>(TAggregate aggregate, CreateOrder command)
    {
        return Array.Empty<string>();
    }
}

