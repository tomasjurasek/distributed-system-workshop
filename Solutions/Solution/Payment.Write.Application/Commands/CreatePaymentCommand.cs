using MediatR;
using Order.Contracts;

namespace Order.Write.Application.Commands
{
    public record CreateOrderCommand : IRequest
    {
        public string  Currency { get; init; }

        public CreateOrderCommandCustomer Customer { get; init; }

        public IReadOnlyCollection<CreateOrderProduct> Products { get; init; }
    }


    public record CreateOrderCommandAddress : Address
    {
        public CreateOrderCommandAddress(string City, string Street, string Number, string PostalCode, string Country) : base(City, Street, Number, PostalCode, Country)
        {
        }
    }

    public record CreateOrderCommandCustomer : Customer
    {
        public CreateOrderCommandCustomer(Guid Id, string FirstName, string LastName, string Email, CreateOrderCommandAddress Address) : base(Id, FirstName, LastName, Email, Address)
        {
        }
    }

    public record CreateOrderProduct : Product
    {
        public CreateOrderProduct(Guid Id, decimal Amount) : base(Id, Amount)
        {
        }
    }
}
