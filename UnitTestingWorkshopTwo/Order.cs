using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestingWorkshopTwo
{
    public class Order
    {
        public Guid Id { get; } = Guid.NewGuid();
        public List<(string Item, int Quantity)> ItemLines { get; } = new List<(string Item, int Quantity)>();
        public string ContactName { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime Created { get; } = DateTime.UtcNow;
        public DateTime? EstimatedShippingDate { get; set; }

        public override string ToString()
        {
            var itemsString = string.Join(", ",
                ItemLines.Select(line=> $"{line.Item} x {line.Quantity}"));
            return $"{Id}: [{itemsString}]";
        }
    }
}