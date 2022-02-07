using Writer.Domain.Aggregates;

namespace Writer.Application.Interfaces;

public interface IAggregateLoader
{
    Task<IAggregateRoot?> LoadAsync(Guid id);
}

