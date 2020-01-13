using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Interfaces
{
    public interface IStoreRepository
    {
        Task<List<Store>> GetAllStores();
        Task<Either<Failure, Store>> AddStore(Store store);
        Task<Option<Failure>> RemoveStore(int storeId);
    }
}
