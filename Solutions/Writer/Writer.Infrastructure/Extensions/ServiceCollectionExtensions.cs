using Microsoft.Extensions.DependencyInjection;
using Writer.Domain.Aggregates;
using Writer.Infrastructure.Repositories;

namespace Writer.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IAggregateRepository<OrderAggregate>, AggregateRepository<OrderAggregate>>(); // TODO generic
        return services;
    }
}

