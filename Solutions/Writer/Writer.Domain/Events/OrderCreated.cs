namespace Writer.Domain.Events;

public record OrderCreated : IEvent
{
    public Guid Id { get; init; }

    public Contact Contact { get; init; }
}

public record Contact
{
    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string Email { get; init; }
}

