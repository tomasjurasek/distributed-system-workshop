using MediatR;
using Payment.Write.Application.Metrics;
using Payment.Write.Domain.Entities;
using Payment.Write.Domain.Repositories;

namespace Payment.Write.Application.Commands.Handlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMetrics _metrics;

        public CreatePaymentCommandHandler(IPaymentRepository paymentRepository, IMetrics metrics)
        {
            _paymentRepository = paymentRepository;
            _metrics = metrics;
        }
        public async Task Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = new PaymentAggregate(request.OrderId, request.Amount, request.Currency);

            await _paymentRepository.StoreAsyc(payment);
            _metrics.PaymentCreated();
        }
    }
}