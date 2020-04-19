using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.Common;
using Monad;
using Monad.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class IceCreamDetailViewModel : PageViewModel
	{
		private List<Store> stores = new List<Store>();

		public IceCream IceCream { get; set; }

		public List<Store> Stores
		{
			get => stores;
			set
			{
				stores = value;
				OnPropertyChanged("Stores");
			}
		}

		private RemoveIceCream RemoveIceCream { get; set; }

		private GetStoreSellingIceCream GetStoreSellingIceCream { get; set; }

		public RelayCommand RemoveIceCreamCommand { get; set; }

		public RelayCommand NavigateToStoreDetailPage { get; set; }

		public IceCreamDetailViewModel(IceCream iceCream)
		{
			IceCream = iceCream;

			RemoveIceCream = Injector.Resolve<RemoveIceCream>();

			GetStoreSellingIceCream = Injector.Resolve<GetStoreSellingIceCream>();

			RemoveIceCreamCommand = new RelayCommand(RemoveIceCreamExecute);

			NavigateToStoreDetailPage = new RelayCommand(
				(o) => Navigator.Push(new StoreDetailPageViewModel(o as Store))
			);
		}

		public override void OnResumed()
		{
			Task.Run(
				async () =>
				{
					var result = await GetStoreSellingIceCream.Call(new GetStoreSellingIceCreamArgs(IceCream.Id));

					if (result.Count != Stores.Count)
						Stores = result;
				}
			);
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