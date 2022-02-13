using Writer.Domain.Commands;

namespace Writer.Application;

public record CommandEnvelope : ICommandEnvelope
{
    public DateTime CreatedAt { get; init; }

    public CommandType Type { get; init; }

    public Guid CorrelationId { get; init; }

    public ICommand Data { get; init; }

    public int Version { get; init; }
}


public interface ICommandEnvelope
{
    public DateTime CreatedAt { get; init; }

    public int Version { get; init; }

    public CommandType Type { get; init; }

    public Guid CorrelationId { get; init; }

    public ICommand Data { get; init; }

}

