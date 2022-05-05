using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestingWorkshopTwo
{
    internal class OrderRepo
    {
        private readonly List<Order> _orderStore = new List<Order>();

        public void Add(Order order)
        {
            _orderStore.Add(order);
        }

        public void Delete(Order order)
        {
            _orderStore.Remove(order);
        }

        public void Delete(Guid id)
        {
            Delete(Get(id));
        }

        public Order Get(Guid id)
        {
            var order = _orderStore.SingleOrDefault(o => o.Id == id);

            if (order == null)
                throw new Exception("No order found");

            return order;
        }
    }
}