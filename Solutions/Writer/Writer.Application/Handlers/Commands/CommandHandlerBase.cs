using MassTransit;
using Newtonsoft.Json;
using Writer.Application.Interfaces;
using Writer.Domain.Aggregates;
using Writer.Domain.Commands;
namespace Writer.Application.Handlers.Commands;

public abstract class CommandHandlerBase<TAggregate, TCommand> : ICommandHandler<TAggregate>
    where TAggregate : IAggregateRoot
    where TCommand : ICommand, new()
{
    private readonly IAggregateLoader<TAggregate> _loader;
    private readonly IEventStore _eventStore;

    public CommandHandlerBase(IAggregateLoader<TAggregate> loader, IEventStore eventStore)
    {

        _loader = loader;
        _eventStore = eventStore;
    }
    public async Task Consume(ConsumeContext<CommandEnvelope> context)
    {
        var envelope = context.Message;
        var command = (TCommand)JsonConvert.DeserializeObject(envelope.Data.ToString());
        var aggregate = await _loader.LoadAsync(command.GetAggregateId());

        await Consume(aggregate, command);

        await _eventStore.StoreAsync(aggregate.UncommitedEvents.ToArray());
    }

    private Type GetCommandType(CommandType type)
    {
        return type switch
        {
            CommandType.CreateOrder => typeof(CreateOrder),
            _ => throw new ArgumentOutOfRangeException(),
        };
    }


    protected abstract Task Consume(TAggregate aggregate, TCommand command);

}

