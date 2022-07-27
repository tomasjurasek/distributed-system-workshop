using MassTransit;
using Writer.Application.Interfaces;
using Writer.Domain.Commands;

namespace Writer.Application;

internal class Publisher : IPublisher
{
    private readonly IPublishEndpoint _publisher;

    public Publisher(IPublishEndpoint publisher)
    {
        _publisher = publisher;
    }
    public async Task PublisAsync(ICommand command)
    {
        //await _publisher.Publish(new CommandEnvelope
        //{
        //    CreatedAt = DateTime.UtcNow,
        //    Type = CommandType.CreatePayment, // TODO Type
        //    Data = command
        //});
    }
}

