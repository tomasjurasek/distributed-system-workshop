namespace Order.Write.Domain.Entities
{
    public record AggregateOperationResult(bool IsSuccess = true, string? Description = null);
}
