using IceCreamDesktop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Interfaces
{
	public interface IReviewRepository
	{
		Task<List<Review>> GetReviewsForProduct(int productId);

		Task<Review> AddReview(Review review);
	}
}