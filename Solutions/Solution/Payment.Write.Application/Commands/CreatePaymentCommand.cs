using MediatR;

namespace Payment.Write.Application.Commands
{
    public record CreatePaymentCommand : IRequest
    {
        public decimal Amount { get; init; }
        public string  Currency { get; init; }
        public Guid OrderId { get; init; }
    }
}
