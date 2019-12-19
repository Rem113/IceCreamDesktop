namespace IceCreamDesktop.Core.Entities
{
    public class IceCream
    {
        public string Id { get; }
        public string Name { get; }
        public string Brand { get; }
        public string ImageUrl { get; }

        public IceCream(string id, string name, string brand, string imageUrl)
        {
            Id = id;
            Name = name;
            Brand = brand;
            ImageUrl = imageUrl;
        }
    }
}
