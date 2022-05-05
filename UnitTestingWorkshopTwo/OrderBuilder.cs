using System;

namespace UnitTestingWorkshopTwo
{
    public class OrderBuilder: IOrderBuilder
    {
        public IOrderBuilder Init()
        {
            throw new NotImplementedException();
        }

        public IOrderBuilder AddItems(int numItems)
        {
            throw new NotImplementedException();
        }

        public IOrderBuilder ShipTo(string contact, string address)
        {
            throw new NotImplementedException();
        }

        public Order Build()
        {
            throw new NotImplementedException();
        }
    }
}