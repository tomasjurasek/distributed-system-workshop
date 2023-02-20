using MediatR;
using Payment.Write.Domain.Entities;
using Payment.Write.Domain.Repositories;

namespace Payment.Write.Application.Commands.Handlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand>
    {
        private readonly IPaymentRepository _paymentRepository;

        public CreatePaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = new PaymentAggregate(request.Amount, request.Currency);

            await _paymentRepository.StoreAsyc(payment);
        }
    }
}
