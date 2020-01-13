using System.Collections.Generic;

namespace IceCreamDesktop.Core.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string Telephone { get; set; }
        public string Website { get; set; }

        public virtual List<Product> IceCreams { get; set; }
    }
}