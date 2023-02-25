using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Read.Application.Queries;

namespace Order.Read.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var order = await _mediator.Send(new GetOrderQuery { Id = id });

            if(order is null)
            {
                return NoContent();
            }

            return Ok(order);
        }
    }
}