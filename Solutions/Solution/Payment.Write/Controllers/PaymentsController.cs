using Microsoft.AspNetCore.Mvc;
using Payment.Write.Domain.Entities;
using Payment.Write.Domain.Repositories;
using System.Diagnostics.Metrics;

namespace Payment.Write.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private static Counter<int>  counter = new Meter("Payment").CreateCounter<int>("payment-created", "Payment");

        private readonly ILogger<PaymentsController> _logger;
        private readonly IPaymentRepository repo;

        public PaymentsController(ILogger<PaymentsController> logger,
            IPaymentRepository repo)
        {
            _logger = logger;
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            counter.Add(1);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var payment = PaymentAggregate.Create();
            await repo.StoreAsyc(payment);
            counter.Add(1);
            return Ok();
        }
    }
}