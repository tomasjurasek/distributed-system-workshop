namespace Writer.Domain.Commands;

public record CreatePayment : ICommand
{
    public Guid OrderId { get; init; }

    public string Currency { get; init; }

    public decimal Amount { get; init; }

    public Guid GetAggregateId() => Guid.Empty;
}

