using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
	public class GetReviewForProduct : IUsecase<List<Review>, GetReviewForProductArgs>
	{
		private IReviewRepository Repository;

		public GetReviewForProduct(IReviewRepository repository)
		{
			Repository = repository;
		}

		public Task<List<Review>> Call(GetReviewForProductArgs args)
		{
			return Repository.GetReviewsForProduct(args.ProductId);
		}
	}

	public class GetReviewForProductArgs : IArgs
	{
		public int ProductId;

		public GetReviewForProductArgs(int productId)
		{
			ProductId = productId;
		}
	}
}