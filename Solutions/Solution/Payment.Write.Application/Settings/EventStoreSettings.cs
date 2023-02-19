namespace Payment.Write.Application.Settings
{
    public record EventStoreSettings
    {
        public string ConnectionString { get; init; }
    }
}
