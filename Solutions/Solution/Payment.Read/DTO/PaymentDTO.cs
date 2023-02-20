namespace Payment.Read.DTO
{
    public record PaymentDTO
    {
        public Guid Id { get; init; }
        public decimal Amount { get; init; }
        public string Currency { get; init; }
    }
}
