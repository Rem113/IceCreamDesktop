using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Data;
using IceCreamDesktop.Data.Repositories;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.ViewModels.Commands;
using Monad;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private readonly GetAllIceCreams GetAllIceCreams;
		private readonly AddIceCream AddIceCream;

		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableCollection<IceCream> IceCreams { get; set; }
		public string IceCreamNameText { get; set; }
		public string IceCreamBrandText { get; set; }
		public string IceCreamImageUrlText { get; set; }

		public RelayCommand AddIceCreamCommand
		{
			get
			{
				return new RelayCommand(o =>
				{
					ExecuteAddIceCreamCommand(new IceCream
					{
						Name = IceCreamNameText,
						Brand = IceCreamBrandText,
						ImageUrl = IceCreamImageUrlText
					});
				}, o => true);
			}
		}

		public MainWindowViewModel()
		{
			KioskContext kiosk = new KioskContext();
			IceCreamRepository repository = new IceCreamRepository(kiosk);

			GetAllIceCreams = new GetAllIceCreams(repository);
			AddIceCream = new AddIceCream(repository);

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
			var result = await AddIceCream.Call(new AddIceCreamArgs(iceCream));

			result.Match(
				Left: failure => MessageBox.Show(failure.Message),
				Right: iceCream => {
					IceCreams.Add(iceCream);

					// Clear inputs
					IceCreamNameText = string.Empty;
					IceCreamBrandText = string.Empty;
					IceCreamImageUrlText = string.Empty;

					RaisePropertyChanged("IceCreamNameText");
					RaisePropertyChanged("IceCreamBrandText");
					RaisePropertyChanged("IceCreamImageUrlText");
				}
			).Invoke();
		}
	}
}