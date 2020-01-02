using System.Collections.Generic;

namespace IceCreamDesktop.Core.Entities
{
    public class Store
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string Telephone { get; set; }
        public string Website { get; set; }
        public List<StoreIceCream> IceCreams { get; set; }

        public Store(string name, string address, string imageUrl, string telephone, string website, string id = null, List<StoreIceCream> iceCreams = null)
        {
            Id = id;
            Name = name;
            Address = address;
            ImageUrl = imageUrl;
            Telephone = telephone;
            Website = website;
            IceCreams = iceCreams;
        }
    }
}
