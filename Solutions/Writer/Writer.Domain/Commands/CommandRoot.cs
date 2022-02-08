namespace Writer.Domain.Commands;

public abstract record CommandRoot : ICommand
{
    public DateTime CreatedAt { get; init; }

    public abstract CommandType Type { get; }

    public Guid CorrelationId { get; init; }

    public abstract Guid GetAggregateId();
}

public interface ICommand
{
    public DateTime CreatedAt { get; init; }

    public abstract CommandType Type { get; }

    public abstract Guid GetAggregateId();

    public Guid CorrelationId { get; init; }
}

