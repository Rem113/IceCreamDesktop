using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Presentation.Common;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class AddProductPageViewModel : PageViewModel
	{
		public Store Store { get; set; }

		public AddProductPageViewModel(Store store)
		{
			Store = store;
		}
	}
}