using MediatR;
using Order.Write.Application.Metrics;
using Order.Write.Domain.Entities;
using Order.Write.Domain.Repositories;

namespace Order.Write.Application.Commands.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IMetrics _metrics;

        public CreateOrderCommandHandler(IOrderRepository OrderRepository, IMetrics metrics)
        {
            _OrderRepository = OrderRepository;
            _metrics = metrics;
        }
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var Order = new OrderAggregate(request.Customer, request.Products, request.Currency);

            await _OrderRepository.StoreAsyc(Order);
            _metrics.OrderCreated();
        }
    }
}