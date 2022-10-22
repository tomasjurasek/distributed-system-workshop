using MassTransit;
using Microsoft.Extensions.Logging;
using Writer.Domain.Aggregates;
using Writer.Domain.Aggregates.Root;

namespace Writer.Application.Handlers.Base;

public abstract class CommandHandlerBase<TCommand, TAggregate> : ICommandHandler<TCommand>
    where TCommand : class, ICommand
    where TAggregate : class, IAggregateRoot
{
    private readonly IAggregateRepository<TAggregate> _repository;
    private readonly ILogger<CommandHandlerBase<TCommand, TAggregate>> _logger;

    public CommandHandlerBase(IAggregateRepository<TAggregate> repository,
        ILogger<CommandHandlerBase<TCommand, TAggregate>> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<TCommand> context)
    {
        try
        {
            var aggregate = await _repository.GetAsync(Guid.Empty); // TODO new 
            var errors = await ConsumeAsync(context.Message, aggregate);

            if (errors != null && errors.Any())
            {
                await context.RespondAsync(new ErrorResult
                {
                    Errors = errors.Select(s => s.ToString()).ToList(),
                });
            }
            await context.RespondAsync(new SuccessResult
            {
                Id = aggregate?.Id ?? Guid.Empty, // TODO test
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);

            await context.RespondAsync(new ErrorResult // TODO want this? maybe some generic message
            {
                Errors = new List<string>
                {
                    ex.Message
                }
            });
        }

    }

    protected abstract Task<IList<AggregateError>> ConsumeAsync(TCommand command, TAggregate aggregate);

}

