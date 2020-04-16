using IceCreamDesktop.Presentation.Common;
using System.Collections.Generic;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class NavigatorViewModel : BaseViewModel
	{
		private Stack<PageViewModel> History { get; } = new Stack<PageViewModel>();

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

		public NavigatorViewModel()
		{
			Push(new MenuPageViewModel());
		}
	}
}