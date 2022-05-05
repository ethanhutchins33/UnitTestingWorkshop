using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingWorkshopTwo
{
    class OrderItemRepo
    {
        private readonly string[] items = new[]
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
            var index = new Random().Next(0, items.Length - 1);
            return items[index];
        }
    }
}
