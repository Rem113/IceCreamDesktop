using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;

namespace IceCreamDesktop.Domain.Usecases
{
    public class AddStore : IUsecase<Either<StoreFailure, Store>, AddStoreArgs>
    {
        private IStoreRepository Repository { get; }

        public AddStore(IStoreRepository repository)
        {
            Repository = repository;
        }

        public Either<StoreFailure, Store> Call(AddStoreArgs args)
        {
            return Repository.AddStore(args.Store);
        }
    }

    public class AddStoreArgs : IArgs
    {
        public Store Store { get; }

        public AddStoreArgs(Store store)
        {
            Store = store;
        }
    }
}
