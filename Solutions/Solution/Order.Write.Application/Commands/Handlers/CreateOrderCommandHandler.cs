using MediatR;
using Order.Write.Application.Metrics;
using Order.Write.Domain.Entities;
using Order.Write.Domain.Repositories;

namespace Order.Write.Application.Commands.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMetrics _metrics;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMetrics metrics)
        {
            _orderRepository = orderRepository;
            _metrics = metrics;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new OrderAggregate(request.Customer, request.DeliveryAddress, request.Products, request.Currency);

            await _orderRepository.StoreAsyc(order);
            _metrics.OrderCreated();
        }
    }
}