using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class Navigator : BaseViewModel
	{
		private PageViewModel currentPage;

		private Stack<PageViewModel> History { get; set; } = new Stack<PageViewModel>();

		public PageViewModel CurrentPage
		{
			get => currentPage;
			set
			{
				currentPage = value;
				currentPage.SetNavigator(this);
				OnPropertyChanged("CurrentPage");
			}
		}

		public void Push(PageViewModel page)
		{
			History.Push(page);
			CurrentPage = page;
			CurrentPage.OnCreated();
			CurrentPage.OnResumed();
		}

		public void Pop()
		{
			History.Pop().OnDestroyed();
			CurrentPage = History.Peek();
			CurrentPage.OnResumed();
		}

		public Navigator()
		{
			Push(new MenuPageViewModel());
		}
	}
}