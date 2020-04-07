using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using Monad;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Interfaces
{
	public interface IProductRepository
	{
		Task<Either<Failure, Product>> AddProductToStore(Product product);
	}
}