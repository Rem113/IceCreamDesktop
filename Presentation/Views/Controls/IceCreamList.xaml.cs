using IceCreamDesktop.Core.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace IceCreamDesktop.Presentation.Views.Controls
{
	/// <summary>
	/// Interaction logic for IceCreamList.xaml
	/// </summary>
	public partial class IceCreamList : UserControl
	{
		public ObservableCollection<IceCream> IceCreams
		{
			get { return (ObservableCollection<IceCream>)GetValue(IceCreamsProperty); }
			set { SetValue(IceCreamsProperty, value); }
		}

		public static readonly DependencyProperty IceCreamsProperty =
			DependencyProperty.Register("IceCreams", typeof(ObservableCollection<IceCream>), typeof(IceCreamList));

		public IceCreamList()
		{
			InitializeComponent();
		}
	}
}