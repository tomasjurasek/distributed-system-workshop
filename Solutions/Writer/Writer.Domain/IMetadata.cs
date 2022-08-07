namespace Writer.Domain;

public interface IMetadata
{
    Guid CorrelationId { get; init; }
}

