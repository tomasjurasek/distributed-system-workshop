using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Writer.Application.Handlers.Base;
using Writer.Application.Handlers.CreateOrder;

namespace Writer.API.Controllers;

[ApiController()]
public class CommandsController : ControllerBase
{
    private readonly IRequestClient<CreateOrderCommand> _request;

    public CommandsController(IRequestClient<CreateOrderCommand> request)
    {
        _request = request;
    }

    [HttpPost("v1/create-order")]
    public async Task<ActionResult> CreateOrderAsync(
        [FromBody] CreateOrderCommand command)
    {

        var response = await _request.GetResponse<SuccessResult, ErrorResult>(command);
        if (response.Is(out Response<SuccessResult> success))
        {
            return Ok(success.Message.Id);
        }

        if (response.Is(out Response<ErrorResult> error))
        {
            return BadRequest(error.Message.Errors);
        }

        return Ok(); // TOOD
    }
}
