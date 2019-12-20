using System.Collections.Generic;

namespace IceCreamDesktop.Core.Entities
{
    public class Order
    {
        public string Id { get; set; }
        public List<StoreIceCream> OrderedIceCreams { get; set; }

        public Order(string id, List<StoreIceCream> orderedIceCreams)
        {
            Id = id;
            OrderedIceCreams = orderedIceCreams;
        }

        public Order(List<StoreIceCream> orderedIceCreams)
        {
            Id = null;
            OrderedIceCreams = orderedIceCreams;
        }
    }
}
