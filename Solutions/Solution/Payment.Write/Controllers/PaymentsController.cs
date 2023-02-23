using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Write.Application.Commands;
using System.Diagnostics.Metrics;

namespace Order.Write.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private static Counter<int>  counter = new Meter("Order").CreateCounter<int>("Order-created", "Order");

        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;

        public OrdersController(
            ILogger<OrdersController> logger,
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
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}