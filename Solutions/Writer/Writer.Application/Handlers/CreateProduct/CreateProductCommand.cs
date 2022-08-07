using Writer.Application.Handlers.Base;

namespace Writer.Application.Handlers.CreateProduct;

public record CreateProductCommand : ICommand
{
    public string Code { get; init; }
}
