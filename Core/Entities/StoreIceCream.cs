using IceCreamDesktop.Core.Enums;

namespace IceCreamDesktop.Core.Entities
{
    public class StoreIceCream
    {
        public string Id { get; set; }
        public string StoreId { get; set; }
        public float Price { get; set; }
        public Ratings Rating { get; set; }
        public string Description { get; set; }
        public string BarCode { get; set; }

        public StoreIceCream(string id, string storeId, float price, Ratings rating, string description, string barCode)
        {
            Id = id;
            StoreId = storeId;
            Price = price;
            Rating = rating;
            Description = description;
            BarCode = barCode;
        }

        public StoreIceCream(string storeId, float price, Ratings rating, string description, string barCode)
        {
            Id = null;
            StoreId = storeId;
            Price = price;
            Rating = rating;
            Description = description;
            BarCode = barCode;
        }
    }
}
