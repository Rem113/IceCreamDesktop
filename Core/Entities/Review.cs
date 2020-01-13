using IceCreamDesktop.Core.Enums;

namespace IceCreamDesktop.Core.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Ratings Rating { get; set; }

        public virtual Product Product { get; set; }
    }
}