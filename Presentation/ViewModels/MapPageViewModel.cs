using IceCreamDesktop.Presentation.Common;
using Microsoft.Maps.MapControl.WPF;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class MapPageViewModel : PageViewModel
	{
		private Location location;

		public Location Location
		{
			get => location;
			set
			{
				location = value;
				OnPropertyChanged("Location");
				OnPropertyChanged("MapHelper.Center");
			}
		}

		public MapPageViewModel(Location location)
		{
			Location = location;
		}
	}
}