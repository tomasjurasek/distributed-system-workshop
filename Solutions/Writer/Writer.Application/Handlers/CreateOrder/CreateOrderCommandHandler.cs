using Microsoft.Extensions.Logging;
using Writer.Application.Handlers.Base;
using Writer.Domain.Aggregates;

namespace Writer.Application.Handlers.CreateOrder;

public class CreateOrderCommandHandler : CommandHandlerBase<CreateOrderCommand, OrderAggregate>
{
    public CreateOrderCommandHandler(IAggregateRepository<OrderAggregate> repository,
        ILogger<CreateOrderCommandHandler> logger) : base(repository, logger)
    {
    }

    protected override async Task<IList<AggregateError>> ConsumeAsync(CreateOrderCommand command, OrderAggregate aggregate)
    {
        return null;
    }
}
