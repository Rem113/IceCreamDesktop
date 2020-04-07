using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Data;
using IceCreamDesktop.Data.Repositories;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.ViewModels.Commands;
using Monad;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private readonly GetAllIceCreams GetAllIceCreams;
		private readonly AddIceCream AddIceCream;
		private readonly RemoveIceCream RemoveIceCream;

		public event PropertyChangedEventHandler PropertyChanged;

		// IceCreamList bindings
		public ObservableCollection<IceCream> IceCreams { get; set; }

		public ICommand RemoveIceCreamCommand
		{
			get
			{
				return new RelayCommand(
					o => ExecuteRemoveIceCreamCommand((int)o),
					o => true
				);
			}
		}

		// AddIceCreamForm bindings
		public string IceCreamNameText { get; set; }

		public string IceCreamBrandText { get; set; }
		public string IceCreamImageUrlText { get; set; }
		public bool IsAddingIceCream { get; set; } = false;

		public RelayCommand AddIceCreamCommand
		{
			get
			{
				return new RelayCommand(
					o => ExecuteAddIceCreamCommand(o as IceCream),
					o =>
					{
						var iceCream = o as IceCream;

						return !string.IsNullOrEmpty(iceCream?.Name)
						&& !string.IsNullOrEmpty(iceCream?.Brand)
						&& !string.IsNullOrEmpty(iceCream?.ImageUrl);
					}
				);
			}
		}

		public MainWindowViewModel()
		{
			KioskContext kiosk = new KioskContext();
			IceCreamRepository repository = new IceCreamRepository(kiosk);

			GetAllIceCreams = new GetAllIceCreams(repository);
			AddIceCream = new AddIceCream(repository);
			RemoveIceCream = new RemoveIceCream(repository);

			IceCreams = new ObservableCollection<IceCream>();

			Initialize();
		}

		private async void Initialize()
		{
			(await GetAllIceCreams.Call(new GetAllIceCreamsArgs()))
				.ForEach(i => IceCreams.Add(i));
		}

		private void RaisePropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public async void ExecuteAddIceCreamCommand(IceCream iceCream)
		{
			IsAddingIceCream = true;
			RaisePropertyChanged("IsAddingIceCream");

			var result = await AddIceCream.Call(new AddIceCreamArgs(iceCream));

			IsAddingIceCream = false;
			RaisePropertyChanged("IsAddingIceCream");

			result.Match(
				Left: failure => MessageBox.Show(failure.Message),
				Right: iceCream =>
				{
					IceCreams.Add(iceCream);
				}
			).Invoke();
		}

		public async void ExecuteRemoveIceCreamCommand(int id)
		{
			var result = await RemoveIceCream.Call(new RemoveIceCreamArgs(id));

			result.Match(
				Just: failure =>
				{
					MessageBox.Show(failure.Message);
					return false;
				},
				Nothing: () => IceCreams.Remove(IceCreams.Where(i => i.Id == id).First())
			).Invoke();
		}
	}
}