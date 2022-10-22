using MassTransit;
using Writer.Domain.Aggregates.Root;

namespace Writer.Application.Handlers.Base;

public interface ICommandHandler<TCommand> : IConsumer<TCommand>
    where TCommand : class, ICommand

{

}

