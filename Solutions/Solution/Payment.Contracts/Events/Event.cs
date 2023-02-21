namespace Payment.Contracts.Events
{
    public abstract record Event : IEvent
    {
        public Guid Id { get; init; }
        public Guid AggregateId { get; init; }

        public DateTime CreatedAt { get; init; }
    }
}
