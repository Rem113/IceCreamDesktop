using System.Collections.Generic;

namespace IceCreamDesktop.Core.Entities
{
    public class Order
    {
        public string Id { get; set; }
        public List<StoreIceCream> OrderedIceCreams { get; set; }

        public Order(string id = null, List<StoreIceCream> orderedIceCreams = null)
        {
            Id = id;
            OrderedIceCreams = orderedIceCreams;
        }
    }
}
