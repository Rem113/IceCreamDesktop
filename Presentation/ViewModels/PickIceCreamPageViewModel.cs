using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.Common;
using Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class PickIceCreamPageViewModel : PageViewModel
	{
		private List<IceCream> iceCreams = new List<IceCream>();

		public Store Store { get; set; }

		public List<IceCream> IceCreams
		{
			get => iceCreams;
			set
			{
				iceCreams = value;
				OnPropertyChanged("IceCreams");
			}
		}

		public GetStoreMissingIceCream GetStoreMissingIceCream { get; set; }

		public RelayCommand PickIceCreamCommand { get; set; }

		public PickIceCreamPageViewModel(Store store)
		{
			Store = store;

			GetStoreMissingIceCream = Injector.Resolve<GetStoreMissingIceCream>();

			PickIceCreamCommand = new RelayCommand(
				(o) => Navigator.Push(new AddProductPageViewModel(store, o as IceCream)));
		}

		public override void OnResumed()
		{
			Task.Run(
				async () =>
				{
					var result = await GetStoreMissingIceCream.Call(new GetStoreMissingIceCreamArgs(Store.Id));

					result.Match(
						Left: failure =>
						{
							MessageBox.Show(failure.Message);
							Navigator.Pop();
						},
						Right: list => IceCreams = list
					).Invoke();
				}
			);
		}
	}
}