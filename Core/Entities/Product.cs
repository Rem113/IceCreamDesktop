using IceCreamDesktop.Core.Enums;
using System.Collections.Generic;

namespace IceCreamDesktop.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string BarCode { get; set; }

        public virtual IceCream IceCream { get; set; }
        public virtual List<Review> Reviews { get; set; }
    }
}