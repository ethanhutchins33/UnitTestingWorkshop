using System;

namespace UnitTestingWorkshopTwo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("---Ordering system initialised---");

            IOrderBuilder orderBuilder = new OrderBuilder(new OrderItemRepo(), new DateTimeFacade());

            var order = orderBuilder
                .Init()
                .AddItems(3)
                .ShipTo("Sara", "Taunton")
                .Build();

            Console.WriteLine(order);
        }
    }
}