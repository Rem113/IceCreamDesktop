using IceCreamDesktop.Core.Entities;
using System;
using System.Collections.Generic;
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

namespace IceCreamDesktop.Presentation.Views.Controls
{
	/// <summary>
	/// Interaction logic for IceCreamList.xaml
	/// </summary>
	public partial class IceCreamList : UserControl
	{
		public List<IceCream> IceCreams
		{
			get { return (List<IceCream>)GetValue(IceCreamsProperty); }
			set { SetValue(IceCreamsProperty, value); }
		}

		public static readonly DependencyProperty IceCreamsProperty =
			DependencyProperty.Register("IceCreams", typeof(List<IceCream>), typeof(IceCreamList));

		public IceCreamList()
		{
			InitializeComponent();
		}
	}
}