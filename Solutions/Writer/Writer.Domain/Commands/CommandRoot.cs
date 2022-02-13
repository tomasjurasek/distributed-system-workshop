namespace Writer.Domain.Commands;

public abstract record CommandRoot : ICommand
{
    public abstract Guid GetAggregateId();
}

public interface ICommand
{
    public abstract Guid GetAggregateId();
}

