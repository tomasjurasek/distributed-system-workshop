namespace Writer.Domain;

public interface IContext // TODO naming
{
    Guid CorrelationId { get; init; }
}

