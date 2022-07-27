namespace Writer.Application.Handlers.Commands;

public interface ICommand
{
    public Guid AggregateId { get; }
}

