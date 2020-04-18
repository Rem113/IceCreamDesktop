using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System.Linq;
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

			var products = await Repository.GetProductsOfStore(args.Product.Store.Id);

			if (products.Any(p => p.BarCode == args.Product.BarCode))
				return () => new InvalidInputFailure("There is already another product with this barcode");

			var result = await Repository.AddProductToStore(product);

			return () => result;
		}
	}

	public class AddProductArgs : IArgs
	{
		public Product Product { get; }

		public AddProductArgs(Product product)
		{
			Product = product;
		}
	}
}