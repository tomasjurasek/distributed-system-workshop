using MassTransit;
using Writer.Domain.Aggregates.Root;

namespace Writer.Application.Handlers.Base;

public interface ICommandHandler<TAggregate, TCommand> : IConsumer<ICommandEnvelope<TCommand>>
    where TAggregate : IAggregateRoot
    where TCommand : ICommand

{

}

