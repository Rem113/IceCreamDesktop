using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using Monad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Interfaces
{
    public interface IStoreRepository
    {
        Task<Either<Failure, Store>> AddStore(Store store);

        Task<Either<Failure, Store>> UpdateStore(string storeId, Store store);

        Task<Option<Failure>> RemoveStore(string storeId);

        Task<List<Store>> GetAllStore();
    }
}