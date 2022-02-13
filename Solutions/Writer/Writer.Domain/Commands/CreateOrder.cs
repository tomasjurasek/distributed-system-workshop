namespace Writer.Domain.Commands;

public record CreateOrder : ICommand
{
    public Guid OrderId { get; set; }

    public Guid GetAggregateId() => OrderId;
}

