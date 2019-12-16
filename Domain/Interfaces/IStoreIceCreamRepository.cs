using System.Threading.Tasks;
using Monad;
using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;

namespace IceCreamDesktop.Domain.Interfaces
{
    interface IStoreIceCreamRepository
    {
        Task<Either<Failure, Store>> AddStoreIceCream(string storeId, StoreIceCream storeIceCream);
        Task<Either<Failure, Store>> UpdateStoreIceCream(string storeId, string storeIceCreamId, StoreIceCream storeIceCream);
        Task<Option<Failure>> RemoveStoreIceCream(string storeId, string storeIceCreamId);
    }
}
