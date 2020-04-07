using IceCreamDesktop.Core.Entities;
using System.Data.Entity;

namespace IceCreamDesktop.Data
{
	public class KioskContext : DbContext
	{
		public DbSet<IceCream> IceCreams { get; set; }
		public DbSet<Store> Stores { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Review> Reviews { get; set; }
	}
}