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
        private readonly IDateTimeFacade _dateTimeFacade;
        private Order _order;

        public OrderBuilder(IOrderItemRepo orderItemRepo, IDateTimeFacade dateTimeFacade)
        {
            _orderItemRepo = orderItemRepo;
            _dateTimeFacade = dateTimeFacade;
        }

        public IOrderBuilder Init()
        {
            _order = new Order();
            return this;
        }

        public IOrderBuilder AddItems(int numItems)
        {
            //TODO add x random items from the OrderItemRepo

            for (var i = 0; i < numItems; i++)
            {
                var randomItem = _orderItemRepo.GetRandomItem();
                _order.ItemLines.Add((randomItem, 1));
            }


            //TODO group like items together

            return this;
        }

        public IOrderBuilder ShipTo(string contact, string address)
        {
            //TODO set estimated shipping to three working days from now (don't worry about bank holidays)
            _order.EstimatedShippingDate = _dateTimeFacade.UtcNow().AddDays(3);

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