namespace Order.Read.Application.DTO
{
    public record OrderDTO
    {
        public Guid Id { get; init; }
        public string Currency { get; init; }
    }
}
