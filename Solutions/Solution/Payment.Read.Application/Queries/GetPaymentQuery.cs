using MediatR;
using Payment.Read.Application.DTO;

namespace Payment.Read.Application.Queries
{
    public record GetPaymentQuery : IRequest<PaymentDTO>
    {
        public Guid Id { get; init; }
    }
}
