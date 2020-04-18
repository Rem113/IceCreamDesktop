using IceCreamDesktop.Presentation.Common;
using System;
using System.Collections.Generic;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class NavigatorViewModel : BaseViewModel
	{
		private Stack<PageViewModel> History { get; } = new Stack<PageViewModel>();

		public RelayCommand Back { get; set; }

		public PageViewModel CurrentPage
		{
			get => History.Peek();
		}

		public void Push(PageViewModel page)
		{
			page.SetNavigator(this);

			History.Push(page);
			OnPropertyChanged("CurrentPage");

			CurrentPage.OnCreated();
			CurrentPage.OnResumed();
		}

		public void Pop()
		{
			History.Pop().OnDestroyed();

			OnPropertyChanged("CurrentPage");

			CurrentPage.OnResumed();
		}

		public void PopUntil(Predicate<PageViewModel> predicate)
		{
			while (!predicate(CurrentPage))
				History.Pop().OnDestroyed();

			OnPropertyChanged("CurrentPage");
			CurrentPage.OnResumed();
		}

		public NavigatorViewModel()
		{
			Back = new RelayCommand((o) => Pop());
			Push(new MenuPageViewModel());
		}
	}
}