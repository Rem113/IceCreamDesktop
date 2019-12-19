using IceCreamDesktop.Core.Enums;

namespace IceCreamDesktop.Core.Entities
{
    public class StoreIceCream
    {
        public string Id { get; }
        public string StoreId { get; }
        public float Price { get; }
        public Ratings Rating { get; }
        public string Description { get; }
        public string BarCode { get; }

        public StoreIceCream(string id, string storeId, float price, Ratings rating, string description, string barCode)
        {
            Id = id;
            StoreId = storeId;
            Price = price;
            Rating = rating;
            Description = description;
            BarCode = barCode;
        }
    }
}
