using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payment.Write.Application.Commands;
using System.Diagnostics.Metrics;

namespace Payment.Write.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private static Counter<int>  counter = new Meter("Payment").CreateCounter<int>("payment-created", "Payment");

        private readonly ILogger<PaymentsController> _logger;
        private readonly IMediator _mediator;

        public PaymentsController(
            ILogger<PaymentsController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            counter.Add(1);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}