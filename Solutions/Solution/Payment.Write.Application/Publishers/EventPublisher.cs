using EventStore.Client;
using Microsoft.Extensions.Options;
using Payment.Write.Application.Helpers;
using Payment.Write.Application.Settings;
using Payment.Write.Domain.Events;
using System.Text;
using System.Text.Json;

namespace Payment.Write.Application.Publishers
{
    public class EventPublisher : IEventPublisher
    {
        private EventStoreClient _store;

        public EventPublisher(IOptions<EventStoreSettings> settings)
        {
            var eventStoreClientSettings = EventStoreClientSettings.Create(settings.Value.ConnectionString);
            _store = new EventStoreClient(eventStoreClientSettings);
        }
        public async Task StartAsync()
        {
            await _store.SubscribeToAllAsync(FromAll.Start, EventReceivedAsync, true,
                filterOptions: new SubscriptionFilterOptions(EventTypeFilter.ExcludeSystemEvents()));
        }

        private Task EventReceivedAsync(StreamSubscription _, ResolvedEvent resolvedEvent, CancellationToken c)
        {
            try
            {
                var type = EventTypeHelper.GetType(resolvedEvent.Event.EventType);
                var jsonData = Encoding.UTF8.GetString(resolvedEvent.Event.Data.ToArray());
                var domainEvent = (IEvent)JsonSerializer.Deserialize(jsonData, type);

            }
            catch (Exception e)
            {
                // LOG
            }

            return Task.CompletedTask;
        }
    }

    public interface IEventPublisher
    {
        Task StartAsync();
    }
}
