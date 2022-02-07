namespace Writer.Domain.Commands;

public abstract record CommandRoot : ICommand
{
    public DateTime CreatedAt { get; init; }
}

public interface ICommand
{
    public DateTime CreatedAt { get; }
}

