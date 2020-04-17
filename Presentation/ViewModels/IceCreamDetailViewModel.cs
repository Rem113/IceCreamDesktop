using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.Common;
using Monad;
using Monad.Utility;
using System.Threading.Tasks;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class IceCreamDetailViewModel : PageViewModel
	{
		public IceCream IceCream { get; set; }

		private RemoveIceCream RemoveIceCream { get; set; }

		public RelayCommand RemoveIceCreamCommand { get; set; }

		public IceCreamDetailViewModel(IceCream iceCream)
		{
			IceCream = iceCream;

			RemoveIceCream = Injector.Resolve<RemoveIceCream>();

			RemoveIceCreamCommand = new RelayCommand(RemoveIceCreamExecute);
		}

		private void RemoveIceCreamExecute(object o)
		{
			var result = MessageBox.Show(
				"Are you sure that you want to remove this delicious ice cream?",
				"Remove ice cream",
				MessageBoxButton.YesNo);

			if (result == MessageBoxResult.Yes)
			{
				Task.Run(
					async () =>
					{
						var result = await RemoveIceCream.Call(new RemoveIceCreamArgs(IceCream.Id));

						result.Match(
							Just: failure =>
							{
								MessageBox.Show(failure.Message);
								return Unit.Default;
							},
							Nothing: () =>
							{
								Navigator.Pop();
								return Unit.Default;
							})
						.Invoke();
					}
				);
			}
		}
	}
}