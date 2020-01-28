using IceCreamDesktop.Core.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IceCreamDesktop.Presentation.Views.Controls
{
	public partial class IceCreamList : UserControl
	{
		public ObservableCollection<IceCream> IceCreams
		{
			get { return (ObservableCollection<IceCream>)GetValue(IceCreamsProperty); }
			set { SetValue(IceCreamsProperty, value); }
		}

		public ICommand RemoveIceCreamCommand
		{
			get { return (ICommand)GetValue(RemoveIceCreamCommandProperty); }
			set { SetValue(RemoveIceCreamCommandProperty, value); }
		}

		public static readonly DependencyProperty RemoveIceCreamCommandProperty =
			DependencyProperty.Register("RemoveIceCreamCommand", typeof(ICommand), typeof(IceCreamList));

		public static readonly DependencyProperty IceCreamsProperty =
			DependencyProperty.Register("IceCreams", typeof(ObservableCollection<IceCream>), typeof(IceCreamList));

		public IceCreamList()
		{
			InitializeComponent();
		}
	}
}