using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Enums;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.Common;
using Monad;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class AddReviewPageViewModel : PageViewModel
	{
		private bool isLoading = false;

		public Product Product { get; set; }

		public string RatingValue { get; set; }
		public string ReviewValue { get; set; }

		public RelayCommand AddReviewCommand { get; set; }

		private AddReview AddReview { get; set; }

		public bool IsLoading
		{
			get => isLoading;
			set
			{
				isLoading = value;
				OnPropertyChanged("IsLoading");
			}
		}

		public AddReviewPageViewModel(Product product)
		{
			Product = product;

			AddReview = Injector.Resolve<AddReview>();

			AddReviewCommand = new RelayCommand(AddReviewExecute, AddReviewCanExecute);
		}

		private void AddReviewExecute(object o)
		{
			Task.Run(
				async () =>
				{
					IsLoading = true;

					var review = new Review
					{
						Product = Product,
						Rating = (Ratings)int.Parse(RatingValue),
						Text = ReviewValue
					};

					var result = await AddReview.Call(new AddReviewArgs(review));

					IsLoading = false;

					result.Match(
						Left: failure => MessageBox.Show(failure.Message),
						Right: review => Navigator.Pop()
					).Invoke();
				}
			);
		}

		private bool AddReviewCanExecute(object o)
		{
			return !string.IsNullOrEmpty(RatingValue)
				&& Regex.IsMatch(RatingValue, "^[0-5]$")
				&& !string.IsNullOrEmpty(ReviewValue)
				&& ReviewValue.Trim().Length > 10;
		}
	}
}