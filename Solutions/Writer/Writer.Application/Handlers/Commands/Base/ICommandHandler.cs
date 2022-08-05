using MassTransit;
using Writer.Domain.Aggregates.Root;

namespace Writer.Application.Handlers.Commands.Base;

public interface ICommandHandler<TAggregate, TCommand> : IConsumer<ICommandEnvelope<TCommand>>
    where TAggregate : IAggregateRoot
    where TCommand : ICommand

{

}

