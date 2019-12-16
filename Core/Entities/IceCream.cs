using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Core.Entities
{
    public class IceCream
    {
        public string Id { get; }
        public string Name { get; }
        public string ImageUrl { get; }

        public IceCream(string id, string name, string imageUrl)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
        }
    }
}
