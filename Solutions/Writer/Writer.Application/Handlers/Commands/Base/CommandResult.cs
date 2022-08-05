namespace Writer.Application.Handlers.Commands.Base;
{
    public record CommandResult
    {
        public bool Success { get; init; }
        public IReadOnlyCollection<string> Errors { get; init; }
    }
}
