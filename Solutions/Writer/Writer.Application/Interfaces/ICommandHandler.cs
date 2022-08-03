using MassTransit;
using Writer.Application.Messages;
using Writer.Domain.Aggregates.Root;
using Writer.Domain.Events;

namespace Writer.Application.Interfaces;

public interface ICommandHandler<TAggregate> : IConsumer<IEventEnvelope<IEvent>>
    where TAggregate : IAggregateRoot

{

}

