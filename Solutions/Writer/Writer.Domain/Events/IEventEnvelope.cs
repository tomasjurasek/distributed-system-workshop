﻿using Writer.Domain.Events;
namespace Writer.Domain;

public interface IEventEnvelope<TEvent> where TEvent : IEvent
{
    DateTime CreatedAt { get; init; }

    EventType Type { get; init; }
    int Version { get; init; }

    Guid CorrelationId { get; init; }

    TEvent Event { get; init; }
}
