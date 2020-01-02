using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
    public class RemoveStore : IUsecase<Option<Failure>, RemoveStoreArgs>
    {
        private IStoreRepository Repository { get; }

        public RemoveStore(IStoreRepository repository)
        {
            Repository = repository;
        }

        public Task<Option<Failure>> Call(RemoveStoreArgs args)
        {
            return Repository.RemoveStore(args.StoreId);
        }
    }

    public class RemoveStoreArgs : IArgs
    {
        public string StoreId { get; }

        public RemoveStoreArgs(string storeId)
        {
            StoreId = storeId;
        }
    }
}