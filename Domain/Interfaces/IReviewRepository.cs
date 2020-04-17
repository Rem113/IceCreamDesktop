using IceCreamDesktop.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Interfaces
{
	public interface IReviewRepository
	{
		Task<List<Review>> GetReviewsForProduct(int productId);

		Task<Review> AddReview(Review review);
	}
}