using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
