using Writer.Application.Interfaces;
using Writer.Domain.Aggregates;
using Writer.Domain.Commands;

namespace Writer.Application.Handlers.Commands;

public class CreatePaymentCommandHandler : CommandHandlerBase<Payment, CreatePayment>
{
    private readonly IAggregateLoader<Order> _orderLoader;

    public CreatePaymentCommandHandler(
        IAggregateLoader<Payment> loader,
        IEventStore eventStore,
        IAggregateLoader<Order> orderLoader
        ) : base(loader, eventStore)
    {
        _orderLoader = orderLoader;
    }

    protected override Task Consume(Payment aggregate, CreatePayment command)
    {
        aggregate = Payment.Create(command.OrderId, command.Currency, command.Amount);

        return Task.CompletedTask;
    }

    public override async Task<ICollection<string>> GetValidationErrorsAsync(CreatePayment command)
    {
        var order = await _orderLoader.LoadAsync(command.OrderId);
        if (order is not null)
        {
            return new List<string> { "Order does not exist." };
        }

        return Array.Empty<string>();
    }
}

