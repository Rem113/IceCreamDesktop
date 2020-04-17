using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.Common;
using Monad;
using System;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class AddIceCreamPageViewModel : PageViewModel
	{
		private bool isLoading = false;

		private AddIceCream AddIceCream { get; set; }

		public string NameValue { get; set; }
		public string BrandValue { get; set; }
		public string ImageURLValue { get; set; }

		public bool IsLoading
		{
			get => isLoading;
			set
			{
				isLoading = value;
				OnPropertyChanged("IsLoading");
			}
		}

		public RelayCommand AddIceCreamCommand { get; set; }

		public AddIceCreamPageViewModel()
		{
			AddIceCream = Injector.Resolve<AddIceCream>();

			AddIceCreamCommand = new RelayCommand(AddIceCreamExecute, AddIceCreamCanExecute);
		}

		private bool AddIceCreamCanExecute(object o)
		{
			return !string.IsNullOrEmpty(NameValue)
				&& !string.IsNullOrEmpty(BrandValue)
				&& !string.IsNullOrEmpty(ImageURLValue);
		}

		private async void AddIceCreamExecute(object o)
		{
			IsLoading = true;

			var iceCream = new IceCream
			{
				Name = NameValue,
				Brand = BrandValue,
				ImageUrl = ImageURLValue
			};
			var args = new AddIceCreamArgs(iceCream);

			var result = await AddIceCream.Call(args);

			IsLoading = false;

			result.Match(
				Left: failure => MessageBox.Show(failure.Message),
				Right: iceCream => Navigator.Pop()
			).Invoke();
		}
	}
}