using Writer.Domain.Commands;

namespace Writer.Application.Interfaces;

public interface IPublisher
{
    public Task PublisAsync(ICommand command);
}

