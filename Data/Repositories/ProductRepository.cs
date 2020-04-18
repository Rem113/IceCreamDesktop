using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamDesktop.Data.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private KioskContext Kiosk { get; set; }

		public ProductRepository(KioskContext kiosk)
		{
			Kiosk = kiosk;
		}

		public async Task<Product> AddProductToStore(Product product)
		{
			Kiosk.Products.Add(product);
			await Kiosk.SaveChangesAsync();
			return product;
		}

		public Task<List<Product>> GetProductsOfStore(int storeId)
		{
			return Task.FromResult(Kiosk.Products.Where(product => product.Store.Id == storeId).ToList());
		}

		public async Task RemoveProduct(int productId)
		{
			var product = Kiosk.Products.Where(product => product.Id == productId).FirstOrDefault();

			if (product == default(Product)) throw new ArgumentException("There is no product with this id!");

			Kiosk.Products.Remove(product);
			await Kiosk.SaveChangesAsync();
		}
	}
}