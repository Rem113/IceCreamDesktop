namespace IceCreamDesktop.Core.Entities
{
    public class IceCream
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string ImageUrl { get; set; }

        public IceCream(string id, string name, string brand, string imageUrl)
        {
            Id = id;
            Name = name;
            Brand = brand;
            ImageUrl = imageUrl;
        }

        public IceCream(string name, string brand, string imageUrl)
        {
            Id = null;
            Name = name;
            Brand = brand;
            ImageUrl = imageUrl;
        }
    }
}
