using System.Collections.Generic;

namespace IceCreamDesktop.Core.Entities
{
    public class Order
    {
        public string Id { get; }
        public List<StoreIceCream> OrderedIceCreams { get; }

        public Order(string id, List<StoreIceCream> orderedIceCreams)
        {
            Id = id;
            OrderedIceCreams = orderedIceCreams;
        }
    }
}
