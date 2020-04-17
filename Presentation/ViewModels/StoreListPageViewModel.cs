using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class StoreListPageViewModel : PageViewModel
	{
		private List<Store> stores;
		private List<Store> displayStores = new List<Store>();
		private bool isLoading;

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

		public bool IsLoading
		{
			get => isLoading;
			set
			{
				isLoading = value;
				OnPropertyChanged("IsLoading");
			}
		}

		private GetAllStores GetAllStores { get; set; }

		public RelayCommand NavigateToAddStorePage { get; set; }

		public RelayCommand NavigateToDetailPage { get; set; }

		public RelayCommand NavigateBack { get; set; }

		public StoreListPageViewModel()
		{
			GetAllStores = Injector.Resolve<GetAllStores>();

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
			Task.Run(async () =>
				{
					IsLoading = true;

					var temp = await GetAllStores.Call(new GetAllStoresArgs());

					IsLoading = false;

					if (temp.Count != Stores.Count)
						Stores = temp;
				});
		}
	}
}