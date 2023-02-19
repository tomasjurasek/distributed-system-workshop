using Payment.Write.Application.Publishers;

namespace Payment.Write.HostedService
{
    public class EventPublisherHostedService : BackgroundService
    {
        private readonly IEventPublisher _eventPublisher;

        public EventPublisherHostedService(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _eventPublisher.StartAsync();
        }
    }
}
