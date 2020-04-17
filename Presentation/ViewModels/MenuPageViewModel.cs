using IceCreamDesktop.Presentation.Common;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class MenuPageViewModel : PageViewModel
	{
		public RelayCommand NavigateToIceCreamListPage { get; set; }

		public RelayCommand NavigateToStoreListPage { get; set; }

		public MenuPageViewModel()
		{
			NavigateToIceCreamListPage = new RelayCommand(
				(o) => Navigator.Push(new IceCreamListPageViewModel())
			);

			NavigateToStoreListPage = new RelayCommand(
				(o) => Navigator.Push(new StoreListPageViewModel())
			);
		}
	}
}