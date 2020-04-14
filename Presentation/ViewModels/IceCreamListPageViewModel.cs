using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Data;
using IceCreamDesktop.Data.Repositories;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Threading;

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

	public class IceCreamListPageViewModel : PageViewModel
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

		public RelayCommand NavigateToAddIceCreamPage { get; set; }

		public RelayCommand NavigateBack { get; set; }

		public IceCreamListPageViewModel()
		{
			IceCreams = new List<IceCream>();

			KioskContext kiosk = new KioskContext();
			IceCreamRepository iceCreamRepository = new IceCreamRepository(kiosk);
			GetAllIceCreams = new GetAllIceCreams(iceCreamRepository);

			NavigateToDetailPage = new RelayCommand(
				(o) => Navigator.Push(new IceCreamDetailViewModel(o as IceCream))
			);

			NavigateToAddIceCreamPage = new RelayCommand(
				(o) => Navigator.Push(new AddIceCreamPageViewModel())
			);

			FilterList = new RelayCommand(
				(o) => Filter = new IceCreamFilter(o.ToString())
			);

			NavigateBack = new RelayCommand(
				(o) => Navigator.Pop()
			);
		}

		public override void OnResumed()
		{
			Application.Current.Dispatcher.BeginInvoke(
				DispatcherPriority.Background,
				new Action(async () =>
				{
					var temp = await GetAllIceCreams.Call(new GetAllIceCreamsArgs());

					if (temp.Count != IceCreams.Count)
						IceCreams = temp;
				})
			);
		}
	}
}