using Writer.Domain.Aggregates;
using Writer.Domain.Commands;
namespace Writer.Application.Interfaces;

public interface ICommandHandler<TAggregate, TCommand>
    where TAggregate : IAggregateRoot
    where TCommand : ICommand
{
    Task<ICollection<string>> GetValidationErrorsAsync(TCommand command);

    Task HandleAsync(TCommand command);
}

