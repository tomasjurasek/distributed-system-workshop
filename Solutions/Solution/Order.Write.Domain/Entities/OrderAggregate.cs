using Dawn;
using Order.Contracts;
using Order.Contracts.Events;
using Order.Contracts.Orders.Events;

namespace Order.Write.Domain.Entities
{
    public sealed class OrderAggregate : Aggregate
    {
        public OrderAggregate(Customer customer, Address deliveryAddress, IReadOnlyCollection<Product> products, string currency) : base()
        {

            Guard.Argument(customer, nameof(customer)).NotNull();
            Guard.Argument(customer, nameof(deliveryAddress)).NotNull();
            Guard.Argument(products, nameof(products)).NotNull().NotEmpty();
            Guard.Argument(currency, nameof(currency)).NotNull().NotEmpty();


            Apply(new OrderCreated
            {
                CreatedAt = DateTime.UtcNow,
                Status = OrderStatus.Created,
                DeliveryAddress = deliveryAddress,
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

        public Address DeliveryAddress { get; private set; }


        private IList<Product> _products = new List<Product>();

        public IEnumerable<Product> Products => _products;


        public AggregateOperationResult Cancel()
        {
            if (Status is OrderStatus.WaitingForPayment)
            {

                Apply(new OrderCanceled
                {
                    AggregateId = Id,
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow
                });

                return new AggregateOperationResult();
            }

            return new AggregateOperationResult(false);
        }

        public AggregateOperationResult ChangeDeliveryAddress(string firstName, string lastName, string street, string number, string city, string postalCode, string country)
        {
            if (Status is OrderStatus.Done)
            {
                return new AggregateOperationResult(false);
            }

            Apply(new OrderDeliveryAddressChanged
            {
                AggregateId = Id,
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Address = new Address(firstName, lastName, city, street, number, postalCode, country)
            });

            return new AggregateOperationResult();
        }


        private void On(OrderDeliveryAddressChanged @event)
        {
            DeliveryAddress = @event.Address;
        }

        private void On(OrderCanceled @event)
        {
            Status = OrderStatus.Canceled;
        }

        private void On(OrderCreated @event)
        {
            Id = @event.AggregateId;
            Status = @event.Status;
            CreatedAt = @event.CreatedAt;
            Customer = @event.Customer;
            DeliveryAddress = @event.DeliveryAddress;
            _products = @event.Products.ToList();
        }
    }
}
