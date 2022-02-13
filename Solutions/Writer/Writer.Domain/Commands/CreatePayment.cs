namespace Writer.Domain.Commands;

public record CreatePayment : CommandRoot
{
    public Guid Id { get; init; }

    public Guid OrderId { get; init; }

    public string Currency { get; init; }

    public decimal Amount { get; init; }

    public override Guid GetAggregateId() => Id;
}

