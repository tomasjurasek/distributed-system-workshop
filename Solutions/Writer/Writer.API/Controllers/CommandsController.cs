using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using Writer.Application.Handlers.Base;

namespace Writer.API.Controllers;

[ApiController()]
public class CommandsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommandsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("")]
    public async Task<ActionResult<CommandResult>> SendAsync(ICommandEnvelope<ICommand> command)
    {

        return Ok(new CommandResult
        {

        });
    }
}
