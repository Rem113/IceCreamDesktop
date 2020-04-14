using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Utils;
using IceCreamDesktop.Presentation.ViewModels.Commands;
using MapControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class StoreDetailPageViewModel : BaseViewModel, IPageViewModel
	{
		private Location location;

		private MainWindowViewModel MainWindowViewModel { get; set; }

		public RelayCommand NavigateBack { get; set; }

		public Location Location
		{
			get => location;
			set { location = value; OnPropertyChanged("Location"); }
		}

		public Store Store { get; set; }

		public StoreDetailPageViewModel(MainWindowViewModel mainWindowViewModel, Store store)
		{
			MainWindowViewModel = mainWindowViewModel;
			Store = store;

			NavigateBack = new RelayCommand(
				(o) => MainWindowViewModel.Navigate(new StoreListPageViewModel(MainWindowViewModel))
			);

			Initialize();
		}

		private async void Initialize()
		{
			var (lat, lon) = await LocationUtils.GetLatLong(Store.Address);
			Location = new Location(lat, lon);
		}
	}
}