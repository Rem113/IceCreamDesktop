using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Data;
using IceCreamDesktop.Data.Repositories;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.ViewModels.Commands;
using Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class AddIceCreamPageViewModel : PageViewModel
	{
		private bool isLoading = false;

		private AddIceCream AddIceCream { get; set; }

		public string NameValue { get; set; }
		public string BrandValue { get; set; }
		public string ImageURLValue { get; set; }

		public bool IsLoading
		{
			get => isLoading;
			set
			{
				isLoading = value;
				OnPropertyChanged("IsLoading");
			}
		}

		public RelayCommand AddIceCreamCommand { get; set; }
		public RelayCommand NavigateBack { get; set; }

		public AddIceCreamPageViewModel()
		{
			KioskContext kiosk = new KioskContext();
			IceCreamRepository repository = new IceCreamRepository(kiosk);
			AddIceCream = new AddIceCream(repository);

			NavigateBack = new RelayCommand((o) => Navigator.Pop());

			AddIceCreamCommand = new RelayCommand(AddIceCreamExecute);
		}

		private async void AddIceCreamExecute(object o)
		{
			IsLoading = true;

			var iceCream = new IceCream
			{
				Name = NameValue,
				Brand = BrandValue,
				ImageUrl = ImageURLValue
			};
			var args = new AddIceCreamArgs(iceCream);

			var result = await AddIceCream.Call(args);

			IsLoading = false;

			result.Match(
				Left: failure => MessageBox.Show(failure.Message),
				Right: iceCream => Navigator.Push(new IceCreamListPageViewModel())
			).Invoke();
		}
	}
}