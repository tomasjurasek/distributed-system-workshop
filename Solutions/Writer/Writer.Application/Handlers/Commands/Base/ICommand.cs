namespace Writer.Application.Handlers.Commands.Base;

public interface ICommand
{
    public Guid AggregateId { get; }
}

