using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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