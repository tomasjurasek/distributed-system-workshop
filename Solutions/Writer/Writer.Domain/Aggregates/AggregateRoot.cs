namespace Writer.Domain.Aggregates;

public abstract class AggregateRoot : IAggregateRoot
{
    public Guid Id { get; protected set; }

    public int Version { get; protected set; }

    public DateTime CreatedAt { get; protected set; }

}

public interface IAggregateRoot
{
    public Guid Id { get; }

    public int Version { get; }

    public DateTime CreatedAt { get; }
}

