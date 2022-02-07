namespace Writer.Domain.Aggregates;

public record Contact
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
}

