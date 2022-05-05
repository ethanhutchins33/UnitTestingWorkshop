using System;

namespace UnitTestingWorkshopTwo
{
    public interface IOrderItemRepo
    {
        string GetRandomItem();
    }

    public class OrderItemRepo : IOrderItemRepo
    {
        private readonly string[] _items =
        {
            "Shoes",
            "Hat",
            "Socks",
            "Coat",
            "Umbrella",
            "Jeans",
            "Boots",
            "Cardigan",
            "Yacht"
        };

        public string GetRandomItem()
        {
            var index = new Random().Next(0, _items.Length - 1);
            return _items[index];
        }
    }
}