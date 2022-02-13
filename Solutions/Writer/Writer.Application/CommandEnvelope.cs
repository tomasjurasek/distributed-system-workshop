using System.Data;
using System.Windows.Input;

namespace Writer.Application;

public record CommandEnvelope
{
    public DateTime CreatedAt { get; init; }

    public CommandType Type { get; init; }

    public Guid CorrelationId { get; init; }

    public ICommand Data { get; init; }
}

