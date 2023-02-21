using EventStore.Client;
using Microsoft.Extensions.Options;
using Payment.Contracts.Events;
using Payment.Write.Application.Helpers;
using Payment.Write.Application.Settings;
using Payment.Write.Domain.Entities;
using Payment.Write.Domain.Repositories;
using System.Text;
using System.Text.Json;

namespace Payment.Write.Application
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly EventStoreClient _store;

        public PaymentRepository(IOptions<EventStoreSettings> settings)
        {
            var eventStoreClientSettings = EventStoreClientSettings.Create(settings.Value.ConnectionString);
            _store = new EventStoreClient(eventStoreClientSettings);
        }
        public async Task<PaymentAggregate> GetAsync(Guid id, CancellationToken cancellationToken = default)
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

            return new PaymentAggregate(parsedEvents!);

        }

        public async Task StoreAsyc(PaymentAggregate aggregate, CancellationToken cancellationToken = default)
        {
            var eventData = aggregate.UncommitedEvents
                .Select(s =>  
                    new EventData(Uuid.FromGuid(s.Id), s.GetType().Name, new ReadOnlyMemory<byte>(JsonSerializer.SerializeToUtf8Bytes(s))));
            await _store.AppendToStreamAsync(aggregate.Id.ToString(), StreamState.Any, eventData);
        }
    }
}
