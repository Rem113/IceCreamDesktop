using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Data;
using IceCreamDesktop.Data.Repositories;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.ViewModels.Commands;
using Monad;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class AddStorePageViewModel : BaseViewModel, IPageViewModel
	{
		private bool isLoading = false;

		private AddStore AddStore { get; set; }

		private MainWindowViewModel MainWindowViewModel { get; set; }

		public RelayCommand NavigateBack { get; set; }

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

		public AddStorePageViewModel(MainWindowViewModel mainWindowViewModel)
		{
			MainWindowViewModel = mainWindowViewModel;

			KioskContext kiosk = new KioskContext();
			StoreRepository repository = new StoreRepository(kiosk);
			AddStore = new AddStore(repository);

			NavigateBack = new RelayCommand(
				(o) => MainWindowViewModel.Navigate(new StoreListPageViewModel(MainWindowViewModel))
			);

			AddStoreCommand = new RelayCommand(AddStoreExecute);
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
				Right: store => MainWindowViewModel.Navigate(new StoreListPageViewModel(MainWindowViewModel))
			).Invoke();
		}
	}
}