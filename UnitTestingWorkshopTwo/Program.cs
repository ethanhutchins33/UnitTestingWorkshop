using System;

namespace UnitTestingWorkshopTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Ordering system initialised---");

            IOrderBuilder orderBuilder = new OrderBuilder();

            Order order = orderBuilder
                .Init()
                .AddItems(3)
                .ShipTo("Sara", "Taunton")
                .Build();

            Console.WriteLine(order);
        }
    }
}
