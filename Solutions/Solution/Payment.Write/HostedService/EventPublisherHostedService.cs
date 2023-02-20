using Payment.Write.Application.Publishers;

namespace Payment.Write.HostedService
{
    public class EventPublisherHostedService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public EventPublisherHostedService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var eventPublisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>();
                await eventPublisher.StartAsync();
            }
          
        }
    }
}
