namespace Writer.Domain.Events;

public record OrderCreated : EventRoot
{
    public Guid Id { get; init; }

    public Contact Contact { get; init; }

    public override EventType Type => throw new NotImplementedException();
}

public record Contact
{
    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string Email { get; init; }
}

