namespace Writer.Domain.Aggregates.Factories
{
    public class ProductAggregateFactory 
    {
        public static ProductAggregate Create(string code, string description, string imageUrl, int quantity, DateTime createdAt) => new ProductAggregate(code, description, imageUrl, quantity, createdAt);

    }
}
