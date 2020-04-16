using IceCreamDesktop.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Presentation.Common
{
	public abstract class PageViewModel : BaseViewModel
	{
		protected NavigatorViewModel Navigator { get; set; }

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