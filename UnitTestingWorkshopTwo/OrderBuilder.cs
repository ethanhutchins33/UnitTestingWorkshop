using System;

namespace UnitTestingWorkshopTwo
{
    public interface IOrderBuilder
    {
        IOrderBuilder Init();
        IOrderBuilder AddItems(int numItems);
        IOrderBuilder ShipTo(string contact, string address);
        Order Build();
    }

    public class OrderBuilder : IOrderBuilder
    {
        private readonly IOrderItemRepo _orderItemRepo;
        private Order _order;

        public OrderBuilder(IOrderItemRepo orderItemRepo)
        {
            _orderItemRepo = orderItemRepo;
        }

        public IOrderBuilder Init()
        {
            _order = new Order();
            return this;
        }

        public IOrderBuilder AddItems(int numItems)
        {
            //TODO add x random items from the OrderItemRepo
            //TODO group like items together

            throw new NotImplementedException();
        }

        public IOrderBuilder ShipTo(string contact, string address)
        {
            //TODO set estimated shipping to three working days from now (don't worry about bank holidays)

            _order.ContactName = contact;
            _order.ShippingAddress = address;
            return this;
        }

        public Order Build()
        {
            if (_order == null)
                throw new InvalidOperationException("Must initialise before building");
            return _order;
        }
    }
}