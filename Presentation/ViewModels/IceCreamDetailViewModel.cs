using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Presentation.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class IceCreamDetailViewModel : PageViewModel
	{
		public IceCream IceCream { get; set; }

		public RelayCommand NavigateBack { get; set; }

		public IceCreamDetailViewModel(IceCream iceCream)
		{
			IceCream = iceCream;

			NavigateBack = new RelayCommand((o) => Navigator.Pop());
		}
	}
}