using EventStore.Client;
using Microsoft.Extensions.Options;
using Order.Contracts.Events;
using Order.Write.Application.Helpers;
using Order.Write.Application.Settings;
using Order.Write.Domain.Entities;
using Order.Write.Domain.Repositories;
using System.Text;
using System.Text.Json;

namespace Order.Write.Application
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EventStoreClient _store;

        public OrderRepository(IOptions<EventStoreSettings> settings)
        {
            var eventStoreClientSettings = EventStoreClientSettings.Create(settings.Value.ConnectionString);
            _store = new EventStoreClient(eventStoreClientSettings);
        }
        public async Task<OrderAggregate> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var events = await _store
                .ReadStreamAsync(
                    Direction.Forwards, 
                    id.ToString(), 
                    StreamPosition.Start, 
                    cancellationToken: cancellationToken)
                .ToListAsync();

            var parsedEvents = events
                .Select(s => (IEvent)JsonSerializer.Deserialize(Encoding.UTF8.GetString(s.Event.Data.ToArray()), EventTypeHelper.GetType(s.Event.EventType)))
                .ToList();

            if(parsedEvents is null || !parsedEvents.Any())
            {
                throw new Exception();
            }

            return new OrderAggregate(parsedEvents!);

        }

        public async Task StoreAsyc(OrderAggregate aggregate, CancellationToken cancellationToken = default)
        {
            var eventData = aggregate.UncommitedEvents
                .Select(s =>  
                    new EventData(Uuid.FromGuid(s.Id), s.GetType().Name, new ReadOnlyMemory<byte>(JsonSerializer.SerializeToUtf8Bytes(s))));
            await _store.AppendToStreamAsync(aggregate.Id.ToString(), StreamState.Any, eventData);
        }
    }
}
