namespace Writer.Application.Handlers.Commands.Base;

public interface ICommandEnvelope<TCommand> where TCommand : ICommand
{
    DateTime CreatedAt { get; init; }

    CommandType Type { get; init; }

    Guid CorrelationId { get; init; }

    TCommand Command { get; init; }
}
