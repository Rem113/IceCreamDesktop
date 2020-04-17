using IceCreamDesktop.Presentation.Common;
using System.Windows;

namespace IceCreamDesktop.Presentation
{
	public partial class App : Application
	{
		public App()
		{
			Injector.Init();
		}
	}
}