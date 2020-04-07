using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
	public class GetAllStores : IUsecase<List<Store>, GetAllStoresArgs>
	{
		private readonly IStoreRepository Repository;

		public GetAllStores(IStoreRepository repository)
		{
			Repository = repository;
		}

		public Task<List<Store>> Call(GetAllStoresArgs args)
		{
			return Repository.GetAllStores();
		}
	}

	public class GetAllStoresArgs : IArgs { }
}