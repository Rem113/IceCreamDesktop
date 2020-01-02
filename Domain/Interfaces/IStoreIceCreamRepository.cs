using System.Threading.Tasks;
using Monad;
using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;

namespace IceCreamDesktop.Domain.Interfaces
{
    public interface IStoreIceCreamRepository
    {
        Task<Either<Failure, Store>> UpdateStoreIceCream(string storeId, string storeIceCreamId, StoreIceCream storeIceCream);
        Task<Option<Failure>> RemoveStoreIceCream(string storeId, string storeIceCreamId);
        Task<Either<Failure, Store>> AddStoreIceCream(string storeId, StoreIceCream storeIceCream);
    }
}
