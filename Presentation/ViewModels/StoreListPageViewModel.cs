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
using System.Windows;
using System.Windows.Threading;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class StoreListPageViewModel : PageViewModel
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

		public List<Store> DisplayStores
		{
			get => displayStores;
			set
			{
				displayStores = value;
				OnPropertyChanged("DisplayStores");
			}
		}

		private GetAllStores GetAllStores { get; set; }

		public RelayCommand NavigateToAddStorePage { get; set; }

		public RelayCommand NavigateToDetailPage { get; set; }

		public RelayCommand NavigateBack { get; set; }

		public StoreListPageViewModel()
		{
			KioskContext kiosk = new KioskContext();
			StoreRepository repository = new StoreRepository(kiosk);
			GetAllStores = new GetAllStores(repository);

			Stores = new List<Store>();

			NavigateToAddStorePage = new RelayCommand(
				(o) => Navigator.Push(new AddStorePageViewModel())
			);

			NavigateToDetailPage = new RelayCommand(
				(o) => Navigator.Push(new StoreDetailPageViewModel(o as Store))
			);

			NavigateBack = new RelayCommand((o) => Navigator.Pop());
		}

		public override void OnResumed()
		{
			Application.Current.Dispatcher.BeginInvoke(
				DispatcherPriority.Background,
				new Action(async () =>
				{
					var temp = await GetAllStores.Call(new GetAllStoresArgs());

					if (temp.Count != Stores.Count)
						Stores = temp;
				})
			);
		}
	}
}