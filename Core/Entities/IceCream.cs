namespace IceCreamDesktop.Core.Entities
{
    public class IceCream
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string ImageUrl { get; set; }

        public IceCream(string name, string brand, string imageUrl, string id = null)
        {
            Id = id;
            Name = name;
            Brand = brand;
            ImageUrl = imageUrl;
        }
    }
}