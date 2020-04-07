using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
	public class AddProduct : IUsecase<Either<Failure, Product>, AddProductArgs>
	{
		private readonly IProductRepository Repository;

		public AddProduct(IProductRepository repository)
		{
			Repository = repository;
		}

		public async Task<Either<Failure, Product>> Call(AddProductArgs args)
		{
			var product = args.Product;

			if (product.IceCream == null)
				return () => new InvalidInputFailure("Please specify an ice cream");

			if (product.Store == null)
				return () => new InvalidInputFailure("Please specify a store");

			return await Repository.AddProductToStore(product);
		}
	}

	public class AddProductArgs : IArgs
	{
		public Product Product { get; }
	}
}