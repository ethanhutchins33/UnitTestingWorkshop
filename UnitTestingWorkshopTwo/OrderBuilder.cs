using System;

namespace UnitTestingWorkshopTwo
{
    public class OrderBuilder : IOrderBuilder
    {
        private Order _order;

        public IOrderBuilder Init()
        {
            _order = new Order();
            return this;
        }

        public IOrderBuilder AddItems(int numItems)
        {
            throw new NotImplementedException();
        }

        public IOrderBuilder ShipTo(string contact, string address)
        {
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