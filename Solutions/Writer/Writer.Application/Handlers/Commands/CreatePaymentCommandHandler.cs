using MassTransit;
using Writer.Application.Interfaces;
using Writer.Domain.Aggregates;
using Writer.Domain.Commands;
using Writer.Domain.Validators;

namespace Writer.Application.Handlers.Commands;

internal class CreatePaymentCommandHandler : ICommandHandler<Payment, CreatePayment>
{
    private readonly PaymentValidator _validator;

    public CreatePaymentCommandHandler(PaymentValidator validator)
    {
        _validator = validator;
    }
    public Task Consume(ConsumeContext<CreatePayment> context)
    {
        var command = context.Message;
        throw new NotImplementedException();
    }

    public async Task<ICollection<string>> GetValidationErrorsAsync(CreatePayment command)
    {
        Payment aggregate = null;
        return _validator.GetValidationErrors(aggregate, command).ToList();
    }

}

