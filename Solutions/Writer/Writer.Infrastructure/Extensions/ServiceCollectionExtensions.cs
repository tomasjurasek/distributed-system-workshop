using Microsoft.Extensions.DependencyInjection;
using Writer.Application.Interfaces;
using Writer.Domain.Aggregates;
using Writer.Infrastructure.Storages;

namespace Writer.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IAggregateLoader<Payment>, PaymentLoader>();
        services.AddSingleton<IEventStore, EventStore>();

        return services;
    }
}

