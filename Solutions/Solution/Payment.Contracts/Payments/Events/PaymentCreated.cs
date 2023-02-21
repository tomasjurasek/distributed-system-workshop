namespace Payment.Contracts.Events
{
    public record PaymentCreated : Event
    {
        public Guid OrderId { get; set; }
        public decimal Amount { get; init; }
        public string Currency { get; init; }
        public PaymentStatus Status { get; init; }
    }

    public enum PaymentStatus
    {
        Waiting,
        Paid,
        Canceled
    }
}
