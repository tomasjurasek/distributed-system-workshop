using Payment.Contracts.Events;

namespace Payment.Contracts.Orders.Events
{
    public record OrderCreated : Event
    {
        public IReadOnlyCollection<ProductDTO> Products { get; init; } = new List<ProductDTO>();
        public string Currency { get; init; }
    }

    public record ProductDTO
    {
        public string Ean { get; init; }
        public decimal Price { get; init; }
    }
}
