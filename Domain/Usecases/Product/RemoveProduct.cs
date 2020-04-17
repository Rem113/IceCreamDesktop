using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
	public class RemoveProduct : IUsecase<Option<Failure>, RemoveProductArgs>
	{
		private IProductRepository Repository;

		public RemoveProduct(IProductRepository repository)
		{
			Repository = repository;
		}

		public async Task<Option<Failure>> Call(RemoveProductArgs args)
		{
			try
			{
				await Repository.RemoveProduct(args.ProductId);
				return Option.Nothing<Failure>();
			}
			catch (Exception e)
			{
				return () => new DataAccessFailure(e.Message);
			}
		}
	}

	public class RemoveProductArgs : IArgs
	{
		public int ProductId { get; set; }

		public RemoveProductArgs(int productId)
		{
			ProductId = productId;
		}
	}
}