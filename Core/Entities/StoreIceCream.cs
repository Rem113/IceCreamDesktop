using IceCreamDesktop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Core.Entities
{
    public class StoreIceCream
    {
        public string Id { get; }
        public float Price { get; }
        public Ratings Rating { get; }
        public string Description { get; }
        public string ImageUrl { get; }
        public string BarCode { get; }

        public StoreIceCream(string id, float price, Ratings rating, string description, string imageUrl, string barCode)
        {
            Id = id;
            Price = price;
            Rating = rating;
            Description = description;
            ImageUrl = imageUrl;
            BarCode = barCode;
        }
    }
}
