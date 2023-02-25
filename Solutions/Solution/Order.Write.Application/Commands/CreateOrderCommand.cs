using MediatR;
using Order.Contracts;

namespace Order.Write.Application.Commands
{
    public record CreateOrderCommand : IRequest
    {
        public string Currency { get; init; }

        public CommandCustomer Customer { get; init; }

        public CommandAddress DeliveryAddress { get; init; }

        public IReadOnlyCollection<CommandProduct> Products { get; init; }
    }


    public record CommandAddress : Address
    {
        public CommandAddress(string FirstName, string LastName, string City, string Street, string Number, string PostalCode, string Country) : base(FirstName, LastName, City, Street, Number, PostalCode, Country)
        {
        }
    }

    public record CommandCustomer : Customer
    {
        public CommandCustomer(Guid Id) : base(Id)
        {
        }
    }

    public record CommandProduct : Product
    {
        public CommandProduct(Guid Id, decimal Amount) : base(Id, Amount)
        {
        }
    }
}
