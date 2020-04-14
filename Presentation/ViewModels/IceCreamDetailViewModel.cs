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
	public class IceCreamDetailViewModel : BaseViewModel, IPageViewModel
	{
		private MainWindowViewModel MainWindowViewModel { get; set; }

		public IceCream IceCream { get; set; }

		public RelayCommand NavigateBack { get; set; }

		public IceCreamDetailViewModel(MainWindowViewModel mainWindowViewModel, IceCream iceCream)
		{
			MainWindowViewModel = mainWindowViewModel;

			IceCream = iceCream;

			NavigateBack = new RelayCommand(
				(o) => MainWindowViewModel.Navigate(new IceCreamListPageViewModel(MainWindowViewModel)),
				(o) => true
			);
		}
	}
}