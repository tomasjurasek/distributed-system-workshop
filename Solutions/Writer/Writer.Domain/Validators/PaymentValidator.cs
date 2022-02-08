using Writer.Domain.Aggregates;
using Writer.Domain.Commands;
namespace Writer.Domain.Validators;

public class PaymentValidator
{
    public IEnumerable<string> GetValidationErrors(Payment aggregate, CreatePayment command)
    {
        if(aggregate.Status != PaymentStatus.Unknown)
        {
            yield return $"Payment is {aggregate.Status}";
        }

        if(command.Amount < 0)
        {
            yield return "Command has negative amount";
        }
    }
}

