namespace Order.Write.Application.Settings
{
    public record EventStoreSettings
    {
        public string ConnectionString { get; init; }
    }
}
