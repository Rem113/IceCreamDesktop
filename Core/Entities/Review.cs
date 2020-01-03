using IceCreamDesktop.Core.Enums;

namespace IceCreamDesktop.Core.Entities
{
    public class Review
    {
        public string Id { get; set; }
        public string StoreIceCreamId { get; set; }
        public string Text { get; set; }
        public Ratings Rating { get; set; }
        public string ImageUrl { get; set; }

        public Review(string storeIceCreamId, string text, Ratings rating, string imageUrl, string id = null)
        {
            Id = id;
            StoreIceCreamId = storeIceCreamId;
            Text = text;
            Rating = rating;
            ImageUrl = imageUrl;
        }
    }
}