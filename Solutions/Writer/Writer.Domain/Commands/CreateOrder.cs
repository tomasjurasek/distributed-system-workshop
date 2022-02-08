namespace Writer.Domain.Commands;

public record CreateOrder : CommandRoot
{
    public Guid OrderId { get; set; }

    public override CommandType Type => CommandType.CreateOrder;

    public override Guid GetAggregateId() => OrderId;
}

