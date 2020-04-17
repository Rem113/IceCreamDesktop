using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace IceCreamDesktop.Presentation.Views.Pages
{
	/// <summary>
	/// Interaction logic for StoreDetailPage.xaml
	/// </summary>
	public partial class StoreDetailPage : UserControl
	{
		public StoreDetailPage()
		{
			InitializeComponent();
		}

		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
			e.Handled = true;
		}
	}
}