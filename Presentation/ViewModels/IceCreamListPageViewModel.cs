using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Data;
using IceCreamDesktop.Data.Repositories;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.ViewModels.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class IceCreamFilter
	{
		public string Name { get; set; }

		public IceCreamFilter(string name)
		{
			Name = name;
		}
	}

	public class IceCreamListPageViewModel : BaseViewModel, IPageViewModel
	{
		private List<IceCream> iceCreams;
		private List<IceCream> displayIceCreams = new List<IceCream>();
		private IceCreamFilter filter;

		private List<IceCream> IceCreams
		{
			get => iceCreams;
			set
			{
				iceCreams = value;
				DisplayIceCreams = value;
			}
		}

		public MainWindowViewModel MainWindowViewModel { get; set; }

		public List<IceCream> DisplayIceCreams
		{
			get => displayIceCreams;
			set
			{
				displayIceCreams = value;
				OnPropertyChanged("DisplayIceCreams");
			}
		}

		public GetAllIceCreams GetAllIceCreams { get; set; }

		public IceCreamFilter Filter
		{
			get => filter;
			set
			{
				filter = value;
				var temp = new Regex(filter.Name, RegexOptions.IgnoreCase);
				DisplayIceCreams = IceCreams.Where(ic => temp.IsMatch(ic.Name) || temp.IsMatch(ic.Brand)).ToList();
			}
		}

		public RelayCommand FilterList { get; set; }

		public RelayCommand NavigateToDetailPage { get; set; }

		public IceCreamListPageViewModel(MainWindowViewModel mainWindowViewModel)
		{
			MainWindowViewModel = mainWindowViewModel;

			IceCreams = new List<IceCream>();

			KioskContext kiosk = new KioskContext();
			IceCreamRepository iceCreamRepository = new IceCreamRepository(kiosk);
			GetAllIceCreams = new GetAllIceCreams(iceCreamRepository);

			NavigateToDetailPage = new RelayCommand(
				(o) => MainWindowViewModel.Navigate(new IceCreamDetailViewModel(MainWindowViewModel, o as IceCream)),
				(o) => true
			);

			FilterList = new RelayCommand(
				(o) => Filter = new IceCreamFilter(o.ToString()),
				(o) => true
			);

			Initialize();
		}

		private async void Initialize()
		{
			IceCreams = await GetAllIceCreams.Call(new GetAllIceCreamsArgs());
		}
	}
}