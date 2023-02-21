using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payment.Read.Application.Queries;

namespace Payment.Read.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var payment = await _mediator.Send(new GetPaymentQuery { Id = id });

            if(payment is null)
            {
                return NoContent();
            }

            return Ok(payment);
        }
    }
}