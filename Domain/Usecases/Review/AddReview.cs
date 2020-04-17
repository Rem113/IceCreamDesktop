using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
	public class AddReview : IUsecase<Either<Failure, Review>, AddReviewArgs>
	{
		private IReviewRepository Repository;

		public AddReview(IReviewRepository repository)
		{
			Repository = repository;
		}

		public async Task<Either<Failure, Review>> Call(AddReviewArgs args)
		{
			try
			{
				var result = await Repository.AddReview(args.Review);
				return () => result;
			}
			catch (Exception e)
			{
				return () => new DataAccessFailure(e.Message);
			}
		}
	}

	public class AddReviewArgs : IArgs
	{
		public Review Review { get; set; }

		public AddReviewArgs(Review review)
		{
			Review = review;
		}
	}
}