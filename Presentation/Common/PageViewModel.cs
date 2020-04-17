using IceCreamDesktop.Presentation.ViewModels;

namespace IceCreamDesktop.Presentation.Common
{
	public abstract class PageViewModel : BaseViewModel
	{
		public NavigatorViewModel Navigator { get; set; }

		public void SetNavigator(NavigatorViewModel navigator)
		{
			Navigator = navigator;
		}

		public virtual void OnCreated()
		{
		}

		public virtual void OnResumed()
		{
		}

		public virtual void OnDestroyed()
		{
		}
	}
}