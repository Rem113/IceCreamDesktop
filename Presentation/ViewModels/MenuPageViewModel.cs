using IceCreamDesktop.Presentation.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class MenuPageViewModel : BaseViewModel, IPageViewModel
	{
		public MainWindowViewModel MainWindowViewModel { get; set; }

		public RelayCommand NavigateToIceCreamListPage { get; set; }

		public RelayCommand NavigateToStoreListPage { get; set; }

		public MenuPageViewModel(MainWindowViewModel mainWindowViewModel)
		{
			MainWindowViewModel = mainWindowViewModel;

			NavigateToIceCreamListPage = new RelayCommand(
				(o) => MainWindowViewModel.Navigate(new IceCreamListPageViewModel(MainWindowViewModel))
			);

			NavigateToStoreListPage = new RelayCommand(
				(o) => MainWindowViewModel.Navigate(new StoreListPageViewModel(MainWindowViewModel))
			);
		}
	}
}