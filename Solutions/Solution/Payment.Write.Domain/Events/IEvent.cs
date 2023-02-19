﻿namespace Payment.Write.Domain.Events
{
    public interface IEvent
    {
        Guid Id { get; }
        Guid AggregateId { get; }

        DateTime CreatedAt { get; }
    }
}