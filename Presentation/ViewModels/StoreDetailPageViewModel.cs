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
	public class StoreDetailPageViewModel : PageViewModel
	{
		private Location location;

		public RelayCommand NavigateBack { get; set; }

		public Location Location
		{
			get => location;
			set { location = value; OnPropertyChanged("Location"); }
		}

		public Store Store { get; set; }

		public StoreDetailPageViewModel(Store store)
		{
			Store = store;

			NavigateBack = new RelayCommand((o) => Navigator.Pop());

			Initialize();
		}

		private async void Initialize()
		{
			var (lat, lon) = await LocationUtils.GetLatLong(Store.Address);
			Location = new Location(lat, lon);
		}
	}
}