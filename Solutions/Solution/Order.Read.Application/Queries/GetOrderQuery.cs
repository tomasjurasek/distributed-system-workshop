using MediatR;
using Order.Read.Application.DTO;

namespace Order.Read.Application.Queries
{
    public record GetOrderQuery : IRequest<OrderDTO>
    {
        public Guid Id { get; init; }
    }
}
