using MediatR;

namespace Order.Write.Application.Commands
{
    public record ChangeDeliveryAddressOrderCommand : IRequest
    {
        public Guid Id { get; init; }

        public CommandAddress Address { get; init; }
    }
}
