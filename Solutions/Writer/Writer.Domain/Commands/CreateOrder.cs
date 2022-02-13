using System.Text.Json.Serialization;

namespace Writer.Domain.Commands;

public record CreateOrder : ICommand
{
    public Guid OrderId { get; set; }

    [JsonIgnore]
    public Guid AggregateId => Guid.Empty;
}

