namespace IceCreamDesktop.Core.Entities
{
	public class IceCream
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Brand { get; set; }
		public string ImageUrl { get; set; }
		public double? Energy { get; set; }
		public double? Fat { get; set; }
	}
}