using MediatR;
using Order.Write.Application.Metrics;
using Order.Write.Domain.Repositories;

namespace Order.Write.Application.Commands.Handlers
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMetrics _metrics;

        public CancelOrderCommandHandler(IOrderRepository OrderRepository, IMetrics metrics)
        {
            _orderRepository = OrderRepository;
            _metrics = metrics;
        }

        public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.Id);
            var result = order.Cancel();

            if(result.IsSuccess)
            {
                await _orderRepository.StoreAsyc(order);
                _metrics.OrderCanceled();
            }
            else
            {
                //TBD
            }
        }
    }
}