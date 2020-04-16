using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Usecases;
using IceCreamDesktop.Presentation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class IceCreamListPageViewModel : PageViewModel
	{
		private List<IceCream> iceCreams;
		private List<IceCream> displayIceCreams = new List<IceCream>();
		private string filterText;
		private bool isLoading = false;

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

		public string FilterText
		{
			get => filterText;
			set
			{
				filterText = value;
				var temp = new Regex(value, RegexOptions.IgnoreCase);
				DisplayIceCreams = IceCreams.Where(ic => temp.IsMatch(ic.Name) || temp.IsMatch(ic.Brand)).ToList();
			}
		}

		public bool IsLoading
		{
			get => isLoading;
			set
			{
				isLoading = value;
				OnPropertyChanged("IsLoading");
			}
		}

		public GetAllIceCreams GetAllIceCreams { get; set; }

		public RelayCommand NavigateToDetailPage { get; set; }

		public RelayCommand NavigateToAddIceCreamPage { get; set; }

		public RelayCommand NavigateBack { get; set; }

		public IceCreamListPageViewModel()
		{
			IceCreams = new List<IceCream>();

			GetAllIceCreams = Injector.Resolve<GetAllIceCreams>();

			NavigateToDetailPage = new RelayCommand(
				(o) => Navigator.Push(new IceCreamDetailViewModel(o as IceCream))
			);

			NavigateToAddIceCreamPage = new RelayCommand(
				(o) => Navigator.Push(new AddIceCreamPageViewModel())
			);

			NavigateBack = new RelayCommand(
				(o) => Navigator.Pop()
			);
		}

		public override void OnResumed()
		{
			Task.Run(async () =>
				{
					IsLoading = true;

					var temp = await GetAllIceCreams.Call(new GetAllIceCreamsArgs());

					IsLoading = false;

					if (temp.Count != IceCreams.Count)
						IceCreams = temp;
				});
		}
	}
}