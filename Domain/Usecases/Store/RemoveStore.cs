using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
    public class RemoveStore : IUsecase<Option<Failure>, RemoveStoreArgs>
    {
        private readonly IStoreRepository Repository;

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
        public int StoreId { get; }

        public RemoveStoreArgs(int storeId)
        {
            StoreId = storeId;
        }
    }
}