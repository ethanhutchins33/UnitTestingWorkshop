using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestingWorkshopTwo
{
    public class Order
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Dictionary<string, int> Items { get; } = new Dictionary<string, int>();
        public string ContactName { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime Created { get; } = DateTime.UtcNow;
        public DateTime? Dispatched { get; set; }

        public override string ToString()
        {
            var itemsString = string.Join(", ",
                Items.Select(kvp=> $"{kvp.Key} x {kvp.Value}"));
            return $"{Id}: [{itemsString}]";
        }
    }
}