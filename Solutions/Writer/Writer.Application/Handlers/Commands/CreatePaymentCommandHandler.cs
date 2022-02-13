using Writer.Application.Interfaces;
using Writer.Domain.Aggregates;
using Writer.Domain.Commands;

namespace Writer.Application.Handlers.Commands;

public class CreatePaymentCommandHandler : CommandHandlerBase<Payment, CreatePayment>
{
    public CreatePaymentCommandHandler(IAggregateLoader<Payment> loader, IEventStore eventStore) : base(loader, eventStore)
    {
    }

    protected override Task Consume(Payment aggregate, CreatePayment command)
    {
        throw new NotImplementedException();
    }
}

