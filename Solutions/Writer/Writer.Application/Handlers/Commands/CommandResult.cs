namespace Writer.Application.Handlers.Commands
{
    public record CommandResult
    {
        public bool Success { get; init; }
        public IReadOnlyCollection<string> Errors { get; init; }
    }
}
