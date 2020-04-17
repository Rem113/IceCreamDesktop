using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.Common;
using Monad;
using System;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class AddStorePageViewModel : PageViewModel
	{
		private bool isLoading = false;

		private AddStore AddStore { get; set; }

		public RelayCommand AddStoreCommand { get; set; }

		public bool IsLoading
		{
			get => isLoading;
			set
			{
				isLoading = value;
				OnPropertyChanged("IsLoading");
			}
		}

		public string NameValue { get; set; }
		public string AddressValue { get; set; }
		public string ImageURLValue { get; set; }
		public string TelephoneValue { get; set; }
		public string WebsiteValue { get; set; }

		public AddStorePageViewModel()
		{
			AddStore = Injector.Resolve<AddStore>();

			AddStoreCommand = new RelayCommand(
				AddStoreExecute,
				AddStoreCanExecute
			);
		}

		private bool AddStoreCanExecute(object o)
		{
			return !string.IsNullOrEmpty(NameValue)
				&& !string.IsNullOrEmpty(AddressValue)
				&& !string.IsNullOrEmpty(ImageURLValue)
				&& !string.IsNullOrEmpty(TelephoneValue)
				&& !string.IsNullOrEmpty(WebsiteValue);
		}

		private async void AddStoreExecute(object o)
		{
			IsLoading = true;

			var store = new Store
			{
				Name = NameValue,
				Address = AddressValue,
				ImageUrl = ImageURLValue,
				Telephone = TelephoneValue,
				Website = WebsiteValue
			};

			var args = new AddStoreArgs(store);

			var result = await AddStore.Call(args);

			IsLoading = false;

			result.Match(
				Left: failure => MessageBox.Show(failure.Message),
				Right: store => Navigator.Pop()
			).Invoke();
		}
	}
}