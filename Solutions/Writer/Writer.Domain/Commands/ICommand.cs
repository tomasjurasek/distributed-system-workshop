namespace Writer.Domain.Commands;

public interface ICommand
{
    public Guid AggregateId { get; }
}

