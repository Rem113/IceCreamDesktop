using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.Common;
using Monad;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class AddProductPageViewModel : PageViewModel
	{
		private bool isLoading = false;

		private AddProduct AddProduct { get; set; }

		public Store Store { get; set; }

		public IceCream IceCream { get; set; }

		public RelayCommand AddProductCommand { get; set; }

		public string DescriptionValue { get; set; }
		public string PriceValue { get; set; }
		public string BarcodeValue { get; set; }

		public bool IsLoading
		{
			get => isLoading;
			set
			{
				isLoading = value;
				OnPropertyChanged("IsLoading");
			}
		}

		public AddProductPageViewModel(Store store, IceCream iceCream)
		{
			Store = store;
			IceCream = iceCream;

			AddProduct = Injector.Resolve<AddProduct>();

			AddProductCommand = new RelayCommand(AddProductExecute, AddProductCanExecute);
		}

		public void AddProductExecute(object o)
		{
			Task.Run(
				async () =>
				{
					var product = new Product
					{
						Description = DescriptionValue,
						Price = float.Parse(PriceValue),
						BarCode = BarcodeValue,
						IceCream = IceCream,
						Store = Store
					};

					IsLoading = true;

					var result = await AddProduct.Call(new AddProductArgs(product));

					IsLoading = false;

					result.Match(
						Left: failure => MessageBox.Show(failure.Message),
						Right: product =>
						{
							Navigator.PopUntil((r) => r is StoreDetailPageViewModel);
						}
					).Invoke();
				}
			);
		}

		public bool AddProductCanExecute(object o)
		{
			return !string.IsNullOrEmpty(DescriptionValue)
				&& !string.IsNullOrEmpty(PriceValue)
				&& Regex.IsMatch(PriceValue, "^[0-9]+(.[0-9]{1,2})?$")
				&& !string.IsNullOrEmpty(BarcodeValue)
				&& Regex.IsMatch(BarcodeValue, "^[0-9]{9}$");
		}
	}
}