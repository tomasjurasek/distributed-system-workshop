using System.Text.Json.Serialization;

namespace Writer.Domain.Commands;

public record CreatePayment : ICommand
{
    public Guid OrderId { get; init; }

    public string Currency { get; init; }

    public decimal Amount { get; init; }


    [JsonIgnore]
    public Guid AggregateId => Guid.Empty;
}

