using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Presentation.Common;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace IceCreamDesktop.Presentation.Views.Controls
{
	public partial class IceCreamListControl : UserControl
	{
		public RelayCommand Command
		{
			get { return (RelayCommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		public static readonly DependencyProperty CommandProperty =
			DependencyProperty.Register("Command", typeof(RelayCommand), typeof(IceCreamListControl));

		public List<IceCream> IceCreams
		{
			get { return (List<IceCream>)GetValue(IceCreamsProperty); }
			set { SetValue(IceCreamsProperty, value); }
		}

		public static readonly DependencyProperty IceCreamsProperty =
			DependencyProperty.Register("IceCreams", typeof(List<IceCream>), typeof(IceCreamListControl));

		public IceCreamListControl()
		{
			InitializeComponent();
		}
	}
}