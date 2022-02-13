using MassTransit;
using Writer.Domain.Aggregates;
namespace Writer.Application.Interfaces;

public interface ICommandHandler<TAggregate> : IConsumer<CommandEnvelope>
    where TAggregate : IAggregateRoot

{

}

