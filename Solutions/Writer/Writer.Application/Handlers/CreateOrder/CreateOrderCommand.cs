using Writer.Application.Handlers.Base;

namespace Writer.Application.Handlers.CreateOrder;

public record CreateOrderCommand : ICommand
{
    public string Note { get; init; }
    public string Currency { get; init; }
    public decimal Amount { get; init; }
    public string? Coupon { get; init; }
}
