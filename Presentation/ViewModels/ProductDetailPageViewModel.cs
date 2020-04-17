using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.Common;
using Monad;
using Monad.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class ProductDetailPageViewModel : PageViewModel
	{
		private List<Review> reviews = new List<Review>();

		public Product Product { get; set; }

		public List<Review> Reviews
		{
			get => reviews;
			set
			{
				reviews = value;
				reviews.Sort((r1, r2) => r2.Rating.CompareTo(r1.Rating));
				OnPropertyChanged("Reviews");
				OnPropertyChanged("Average");
			}
		}

		public double Average
		{
			get => Math.Round((double)Reviews.Aggregate(0, (acc, r) => acc + (int)r.Rating) / Reviews.Count, 2);
		}

		private RemoveProduct RemoveProduct { get; set; }

		private GetReviewForProduct GetReviewForProduct { get; set; }

		public RelayCommand NavigateBack { get; set; }

		public RelayCommand NavigateToAddReviewPage { get; set; }

		public RelayCommand RemoveProductCommand { get; set; }

		public ProductDetailPageViewModel(Product product)
		{
			Product = product;

			RemoveProduct = Injector.Resolve<RemoveProduct>();
			GetReviewForProduct = Injector.Resolve<GetReviewForProduct>();

			NavigateBack = new RelayCommand((o) => Navigator.Pop());

			NavigateToAddReviewPage = new RelayCommand((o) => Navigator.Push(new AddReviewPageViewModel(Product)));

			RemoveProductCommand = new RelayCommand(RemoveProductExecute);
		}

		private void RemoveProductExecute(object o)
		{
			var result = MessageBox.Show(
				"Are you sure that you want to remove this product from the store?",
				"Remove product",
				MessageBoxButton.YesNo);

			if (result == MessageBoxResult.Yes)
			{
				Task.Run(
					async () =>
					{
						var result = await RemoveProduct.Call(new RemoveProductArgs(Product.Id));

						result.Match(
							Just: failure =>
							{
								MessageBox.Show(failure.Message);
								return Unit.Default;
							},
							Nothing: () =>
							{
								NavigateBack.Execute(null);
								return Unit.Default;
							})
						.Invoke();
					}
				);
			}
		}

		public override void OnResumed()
		{
			Task.Run(
				async () =>
				{
					var result = await GetReviewForProduct.Call(new GetReviewForProductArgs(Product.Id));

					if (result.Count != Reviews.Count)
						Reviews = result;
				}
			);
		}
	}
}