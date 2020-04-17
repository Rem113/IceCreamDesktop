using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Utils;
using IceCreamDesktop.Presentation.Common;
using Microsoft.Maps.MapControl.WPF;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class StoreDetailPageViewModel : PageViewModel
	{
		public RelayCommand NavigateBack { get; set; }

		public Store Store { get; set; }

		public Location Location { get; set; }

		public RelayCommand NavigateToMapPage { get; set; }

		public RelayCommand OpenBrowserLink { get; set; }

		public StoreDetailPageViewModel(Store store)
		{
			Store = store;

			NavigateBack = new RelayCommand((o) => Navigator.Pop());

			NavigateToMapPage = new RelayCommand(
				(o) => Navigator.Push(new MapPageViewModel(Location)),
				(o) => Location != null
			);

			OpenBrowserLink = new RelayCommand(
				(o) => Process.Start(new ProcessStartInfo(o.ToString()))
			);
		}

		public override void OnCreated()
		{
			Task.Run(async () =>
			{
				var (lat, lon) = await LocationUtils.GetLatLong(Store.Address);
				Location = new Location(lat, lon);
				Application.Current.Dispatcher.Invoke(() => NavigateToMapPage.RaiseCanExecuteChanged());
			});
		}
	}
}