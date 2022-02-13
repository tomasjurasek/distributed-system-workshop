namespace Writer.Domain.Commands;

public interface ICommand
{
    public abstract Guid GetAggregateId();
}

