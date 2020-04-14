using IceCreamDesktop.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Presentation
{
	public abstract class PageViewModel : BaseViewModel
	{
		protected Navigator Navigator { get; set; }

		public void SetNavigator(Navigator navigator)
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