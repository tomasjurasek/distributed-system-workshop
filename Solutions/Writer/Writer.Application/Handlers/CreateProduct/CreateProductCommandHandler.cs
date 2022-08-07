using Writer.Application.Handlers.Base;
using Writer.Domain.Aggregates;

namespace Writer.Application.Handlers.CreateProduct;

public class CreateProductCommandHandler : CommandHandlerBase<ProductAggregate, CreateProductCommand>
{
    protected override Task Consume(ProductAggregate aggregate, CreateProductCommand command, Guid correlationId)
    {
        throw new NotImplementedException();
    }
}
