using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Data;
using IceCreamDesktop.Data.Repositories;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class StoreListPageViewModel : BaseViewModel, IPageViewModel
	{
		private List<Store> stores;
		private List<Store> displayStores = new List<Store>();

		private List<Store> Stores
		{
			get => stores;
			set
			{
				stores = value;
				DisplayStores = value;
			}
		}

		private MainWindowViewModel MainWindowViewModel { get; set; }

		private GetAllStores GetAllStores { get; set; }

		public List<Store> DisplayStores { get; set; }

		public RelayCommand NavigateToAddStorePage { get; set; }

		public RelayCommand NavigateToDetailPage { get; set; }

		public RelayCommand NavigateBack { get; set; }

		public StoreListPageViewModel(MainWindowViewModel mainWindowViewModel)
		{
			MainWindowViewModel = mainWindowViewModel;

			KioskContext kiosk = new KioskContext();
			StoreRepository repository = new StoreRepository(kiosk);
			GetAllStores = new GetAllStores(repository);

			NavigateToAddStorePage = new RelayCommand(
				(o) => MainWindowViewModel.Navigate(new AddStorePageViewModel(MainWindowViewModel))
			);

			NavigateToDetailPage = new RelayCommand(
				(o) => MainWindowViewModel.Navigate(new StoreDetailPageViewModel(MainWindowViewModel, o as Store))
			);

			NavigateBack = new RelayCommand(
				(o) => MainWindowViewModel.Navigate(new MenuPageViewModel(MainWindowViewModel))
			);

			Initialize();
		}

		private async void Initialize()
		{
			Stores = await GetAllStores.Call(new GetAllStoresArgs());
		}
	}
}