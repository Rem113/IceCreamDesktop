using System.Threading.Tasks;
using Monad;
using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using System.Collections.Generic;

namespace IceCreamDesktop.Domain.Interfaces
{
    public interface IStoreRepository
    {
        Either<StoreFailure, Store> AddStore(Store store);
        Either<StoreFailure, Store> UpdateStore(string storeId, Store store);
        Option<StoreFailure> RemoveStore(string storeId);
        List<Store> GetAllStore();
    }
}
