using MassTransit;
using Newtonsoft.Json;
using Writer.Application.Interfaces;
using Writer.Domain.Aggregates;
using Writer.Domain.Aggregates.Root;
using Writer.Domain.Commands;
namespace Writer.Application.Handlers.Commands;

public abstract class CommandHandlerBase<TAggregate, TCommand> : ICommandHandler<TAggregate>
    where TAggregate : IAggregateRoot
    where TCommand : ICommand, new()
{

    public CommandHandlerBase()
    {
      
    }

    public async Task Consume(ConsumeContext<IEvent> context)
    {
        var envelope = context.Message;
        var command = (TCommand)JsonConvert.DeserializeObject(envelope.Data.ToString());


        var errors = await GetValidationErrorsAsync(command);
        if (errors.Any())
        {
            return; // TODO
        }

        var aggregate = await _loader.LoadAsync(command.AggregateId);

        if (aggregate is null)
        {
            //TODO Default
        }

        await Consume(aggregate, command);
        await _eventStore.StoreAsync(aggregate!.UncommitedEvents.ToArray());
    }

    public virtual async Task<ICollection<string>> GetValidationErrorsAsync(TCommand command) => Array.Empty<string>();

    protected abstract Task Consume(TAggregate aggregate, TCommand command);

}

