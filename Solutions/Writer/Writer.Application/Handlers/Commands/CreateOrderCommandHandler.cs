using MassTransit;
using Writer.Application.Interfaces;
using Writer.Domain.Aggregates;
using Writer.Domain.Commands;

namespace Writer.Application.Handlers.Commands;

internal class CreateOrderCommandHandler : ICommandHandler<Order, CreateOrder>
{
    public Task Consume(ConsumeContext<CreateOrder> context)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<string>> GetValidationErrorsAsync(CreateOrder command)
    {
        throw new NotImplementedException();
    }
}

