using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using Monad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Interfaces
{
	public interface IProductRepository
	{
		Task<Product> AddProductToStore(Product product);

		Task<List<Product>> GetProductsOfStore(int storeId);

		Task RemoveProduct(int productId);
	}
}