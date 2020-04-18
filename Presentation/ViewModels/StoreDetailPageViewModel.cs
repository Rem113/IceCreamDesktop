using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Utils;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.Common;
using IceCreamDesktop.Presentation.Views.Pages;
using Microsoft.Maps.MapControl.WPF;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class StoreDetailPageViewModel : PageViewModel
	{
		private List<IceCream> iceCreams = new List<IceCream>();
		private List<Product> products = new List<Product>();

		public Store Store { get; set; }

		public Location Location { get; set; }

		public RelayCommand NavigateToMapPage { get; set; }

		public RelayCommand OpenBrowserLink { get; set; }

		public RelayCommand NavigateToProductDetailPage { get; set; }

		public RelayCommand NavigateToPickIceCreamPage { get; set; }

		public List<IceCream> IceCreams
		{
			get => iceCreams;
			set
			{
				iceCreams = value;
				OnPropertyChanged("IceCreams");
			}
		}

		public List<Product> Products
		{
			get => products;
			set
			{
				products = value;
				IceCreams = value.Select(product => product.IceCream).ToList();
			}
		}

		private GetProductsForStore GetProductsForStore { get; set; }

		public StoreDetailPageViewModel(Store store)
		{
			Store = store;

			GetProductsForStore = Injector.Resolve<GetProductsForStore>();

			NavigateToMapPage = new RelayCommand(
				(o) => Navigator.Push(new MapPageViewModel(Location)),
				(o) => Location != null
			);

			OpenBrowserLink = new RelayCommand(
				(o) => Process.Start(new ProcessStartInfo(o.ToString()))
			);

			NavigateToProductDetailPage = new RelayCommand(
				(o) => Navigator.Push(new ProductDetailPageViewModel(Products.Where(product => product.IceCream.Id == ((IceCream)o).Id).First()))
			);

			NavigateToPickIceCreamPage = new RelayCommand(
				(o) => Navigator.Push(new PickIceCreamPageViewModel(o as Store))
			);
		}

		public override void OnCreated()
		{
			Task.Run(async () =>
			{
				var (lat, lon) = await LocationUtils.GetLatLong(Store.Address);
				Location = new Location(lat, lon);
				Application.Current.Dispatcher.Invoke(() => NavigateToMapPage.RaiseCanExecuteChanged());
			});
		}

		public override void OnResumed()
		{
			Task.Run(async () =>
			{
				var result = await GetProductsForStore.Call(new GetProductsForStoreArgs(Store.Id));

				if (result.Count != Products.Count)
					Products = result;
			});
		}
	}
}