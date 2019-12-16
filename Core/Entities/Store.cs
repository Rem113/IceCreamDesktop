using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Core.Entities
{
    public class Store
    {
        public string Id { get; }
        public string Name { get; }
        public string Address { get; }
        public string ImageUrl { get; }
        public string Telephone { get; }
        public string Website { get; }
        public List<StoreIceCream> IceCreams { get; }

        public Store(string id, string name, string address, string imageUrl, string telephone, string website, List<StoreIceCream> iceCreams)
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
