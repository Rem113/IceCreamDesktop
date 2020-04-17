using IceCreamDesktop.Presentation.Common;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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