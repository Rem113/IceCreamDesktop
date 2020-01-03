using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using Monad;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Interfaces
{
    public interface IStoreIceCreamRepository
    {
        Task<Either<Failure, Store>> UpdateStoreIceCream(string storeId, string storeIceCreamId, StoreIceCream storeIceCream);

        Task<Option<Failure>> RemoveStoreIceCream(string storeId, string storeIceCreamId);

        Task<Either<Failure, Store>> AddStoreIceCream(string storeId, StoreIceCream storeIceCream);
    }
}