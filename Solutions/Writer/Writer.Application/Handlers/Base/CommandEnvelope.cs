namespace Writer.Application.Handlers.Base;

public abstract record CommandEnvelope<TCommand> : ICommandEnvelope<TCommand> where TCommand : ICommand
{
    public DateTime CreatedAt { get; init; }

    public CommandType Type { get; init; }

    public Guid CorrelationId { get; init; }
    public int Version { get; init; }

    public TCommand Command { get; init; }
}

