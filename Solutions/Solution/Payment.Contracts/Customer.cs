namespace Order.Contracts
{
    public record Customer(Guid Id, string FirstName, string LastName, string Email, Address Address);
}
