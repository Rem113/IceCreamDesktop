using IceCreamDesktop.Presentation.Common;
using System.Windows;

namespace IceCreamDesktop.Presentation
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			Injector.Init();
		}
	}
}