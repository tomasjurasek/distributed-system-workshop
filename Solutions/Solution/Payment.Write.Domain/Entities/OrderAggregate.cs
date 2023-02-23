using Dawn;
using Order.Contracts;
using Order.Contracts.Events;
using Order.Contracts.Orders.Events;

namespace Order.Write.Domain.Entities
{
    public class OrderAggregate : Aggregate
    {
        public OrderAggregate(Customer customer, IReadOnlyCollection<Product> products, string currency) : base()
        {

            Guard.Argument(customer, nameof(customer)).NotNull();
            Guard.Argument(products, nameof(products)).NotNull().NotEmpty();
            Guard.Argument(currency, nameof(currency)).NotNull().NotEmpty();


            Apply(new OrderCreated
            {
                CreatedAt = DateTime.UtcNow,
                Status = OrderStatus.Created,
                Currency = currency,
                AggregateId = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                Customer = customer,
                Products = products,
            });
        }

        public OrderAggregate(IList<IEvent> events) : base(events) { }

        public OrderStatus Status { get; private set; }

        public Customer Customer { get; private set; }

        public Address Address { get; private set; }


        private IList<Product> _products  = new List<Product>();

        public IEnumerable<Product> Products => _products;

        private void On(OrderCreated @event)
        {
            Id = @event.AggregateId;
            Status = @event.Status;
            CreatedAt = @event.CreatedAt;
            Customer = @event.Customer;
            Address = @event.Address;
            _products = @event.Products.ToList();
        }
    }
}
