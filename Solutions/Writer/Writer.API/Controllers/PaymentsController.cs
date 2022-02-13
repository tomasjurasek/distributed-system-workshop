using Microsoft.AspNetCore.Mvc;
using Writer.API.Requests;
using Writer.Application.Handlers.Commands;
using Writer.Application.Interfaces;
using Writer.Domain.Commands;

namespace Writer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IPublisher _publisher;
    private readonly CreatePaymentCommandHandler _createPaymentCommandHandler;

    public PaymentsController(IPublisher publisher, CreatePaymentCommandHandler createPaymentCommandHandler)
    {
        _publisher = publisher;
        _createPaymentCommandHandler = createPaymentCommandHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatePaymentRequest request)
    {
        var command = new CreatePayment
        {
            Amount = request.Amount,
            Currency = request.Currency,
            OrderId = request.OrderId,
        };

        var errors = await _createPaymentCommandHandler.GetValidationErrorsAsync(command);
        if (errors.Any())
        {
            return BadRequest(errors);
        }

        await _publisher.PublisAsync(command);
        return Accepted();
    }
}

