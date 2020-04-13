using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		private IPageViewModel _currentPageViewModel;

		public IPageViewModel CurrentPageViewModel
		{
			get
			{
				return _currentPageViewModel;
			}
			set
			{
				_currentPageViewModel = value;
				OnPropertyChanged("CurrentPageViewModel");
			}
		}

		public void Navigate(IPageViewModel pageViewModel)
		{
			CurrentPageViewModel = pageViewModel;
		}

		public MainWindowViewModel()
		{
			CurrentPageViewModel = new MenuPageViewModel(this);
		}
	}
}