using System.Threading.Tasks;
using Monad;
using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;

namespace IceCreamDesktop.Domain.Interfaces
{
    interface IStoreRepository
    {
        Task<Either<Failure, Store>> AddStore(Store store);
        Task<Either<Failure, Store>> UpdateStore(string storeId, Store store);
        Task<Option<Failure>> RemoveStore(string storeId);
    }
}
