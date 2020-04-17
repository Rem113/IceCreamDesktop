using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Data.Repositories
{
	public class ReviewRepository : IReviewRepository
	{
		private KioskContext Kiosk { get; set; }

		public ReviewRepository(KioskContext kiosk)
		{
			Kiosk = kiosk;
		}

		public Task<List<Review>> GetReviewsForProduct(int productId)
		{
			return Task.FromResult(Kiosk.Reviews.Where(review => review.Product.Id == productId).ToList());
		}

		public async Task<Review> AddReview(Review review)
		{
			Kiosk.Reviews.Add(review);
			await Kiosk.SaveChangesAsync();
			return review;
		}
	}
}