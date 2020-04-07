using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
	public class AddStore : IUsecase<Either<Failure, Store>, AddStoreArgs>
	{
		private readonly IStoreRepository Repository;

		public AddStore(IStoreRepository repository)
		{
			Repository = repository;
		}

		public Task<Either<Failure, Store>> Call(AddStoreArgs args)
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