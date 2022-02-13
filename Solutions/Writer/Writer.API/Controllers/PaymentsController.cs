using Microsoft.AspNetCore.Mvc;
using Writer.API.Requests;
using Writer.Application.Interfaces;
using Writer.Domain.Commands;

namespace Writer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IPublisher _publisher;

    public PaymentsController(IPublisher publisher)
    {
        _publisher = publisher;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatePaymentRequest request)
    {
        await _publisher.PublisAsync(new CreatePayment
        {
            Amount = request.Amount,
            Currency = request.Currency,
            OrderId = request.OrderId,
        });

        return Accepted();
    }
}

