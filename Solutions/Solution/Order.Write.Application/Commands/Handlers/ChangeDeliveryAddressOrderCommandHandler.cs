using MediatR;
using Order.Write.Application.Metrics;
using Order.Write.Domain.Repositories;

namespace Order.Write.Application.Commands.Handlers
{
    public class ChangeDeliveryAddressOrderCommandHandler : IRequestHandler<ChangeDeliveryAddressOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeDeliveryAddressOrderCommandHandler(IOrderRepository OrderRepository)
        {
            _orderRepository = OrderRepository;
        }

        public async Task Handle(ChangeDeliveryAddressOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.Id);
            var result = order.ChangeDeliveryAddress(request.Address.FirstName, request.Address.LastName, request.Address.Street, request.Address.Number, request.Address.City, request.Address.PostalCode, request.Address.Country);

            if (result.IsSuccess)
            {
                await _orderRepository.StoreAsyc(order);
            }
            else
            {
                //TBD
            }
        }
    }
}