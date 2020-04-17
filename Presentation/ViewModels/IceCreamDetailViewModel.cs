using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Presentation.Common;

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