using IceCreamDesktop.Core.Enums;

namespace IceCreamDesktop.Core.Entities
{
    public class StoreIceCream
    {
        public string Id { get; set; }
        public float Price { get; set; }
        public Ratings Rating { get; set; }
        public string Description { get; set; }
        public string BarCode { get; set; }

        public StoreIceCream(float price, Ratings rating, string description, string barCode, string id = null)
        {
            Id = id;
            Price = price;
            Rating = rating;
            Description = description;
            BarCode = barCode;
        }
    }
}