using MediatR;

namespace Order.Write.Application.Commands
{
    public record CancelOrderCommand : IRequest
    {
        public Guid Id { get; init; }
    }
}
