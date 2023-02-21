namespace Payment.Contracts.Events
{
    public record PaymentCreated : Event
    {
        public decimal Amount { get; init; }
        public string Currency { get; init; }
    }
}
