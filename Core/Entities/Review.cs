using IceCreamDesktop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Core.Entities
{
    public class Review
    {
        public string Id { get; }
        public string StoreIceCreamId { get; }
        public string Text { get; }
        public Ratings Rating { get; }
        public string ImageUrl { get; }
        
        public Review(string id, string storeIceCreamId, string text, Ratings rating, string imageUrl)
        {
            Id = id;
            StoreIceCreamId = storeIceCreamId;
            Text = text;
            Rating = rating;
            ImageUrl = imageUrl;
        }
    }
}
