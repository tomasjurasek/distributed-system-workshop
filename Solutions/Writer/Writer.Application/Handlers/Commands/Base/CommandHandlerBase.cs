using MassTransit;
using Writer.Application.Interfaces;
using Writer.Domain.Aggregates.Root;
namespace Writer.Application.Handlers.Commands.Base;

public abstract class CommandHandlerBase<TAggregate, TCommand> : ICommandHandler<TAggregate, TCommand>
    where TAggregate : IAggregateRoot
    where TCommand : ICommand, new()
{

    public CommandHandlerBase()
    {
    }

    public Task Consume(ConsumeContext<ICommandEnvelope<TCommand>> context)
    {
        throw new NotImplementedException();
    }

    protected abstract Task Consume(TAggregate aggregate, TCommand command, IMetadata metadata);

}

