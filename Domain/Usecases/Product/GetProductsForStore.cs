using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
	public class GetProductsForStore : IUsecase<List<Product>, GetProductsForStoreArgs>
	{
		private IProductRepository Repository { get; set; }

		public GetProductsForStore(IProductRepository repository)
		{
			Repository = repository;
		}

		public Task<List<Product>> Call(GetProductsForStoreArgs args)
		{
			return Repository.GetProductsOfStore(args.StoreId);
		}
	}

	public class GetProductsForStoreArgs : IArgs
	{
		public int StoreId { get; set; }

		public GetProductsForStoreArgs(int storeId)
		{
			StoreId = storeId;
		}
	}
}