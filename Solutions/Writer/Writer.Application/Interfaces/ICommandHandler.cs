using MassTransit;
using Writer.Domain.Aggregates;
using Writer.Domain.Commands;
namespace Writer.Application.Interfaces;

public interface ICommandHandler<TAggregate, TCommand> : IConsumer<TCommand>
    where TAggregate : IAggregateRoot
    where TCommand : class, ICommand
    
{
    Task<ICollection<string>> GetValidationErrorsAsync(TCommand command);

}

