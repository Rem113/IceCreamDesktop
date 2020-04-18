using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using Monad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Interfaces
{
	public interface IStoreRepository
	{
		Task<List<Store>> GetAllStores();

		Task<List<Store>> GetStoreSellingIceCream(int iceCreamId);

		Task<Either<Failure, Store>> AddStore(Store store);

		Task<Option<Failure>> RemoveStore(int storeId);
	}
}