using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Presentation.Common;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace IceCreamDesktop.Presentation.Views.Controls
{
	/// <summary>
	/// Interaction logic for IceCreamList.xaml
	/// </summary>
	public partial class IceCreamList : UserControl
	{
		public RelayCommand NavigateCommand
		{
			get { return (RelayCommand)GetValue(NavigateCommandProperty); }
			set { SetValue(NavigateCommandProperty, value); }
		}

		public static readonly DependencyProperty NavigateCommandProperty =
			DependencyProperty.Register("NavigateCommand", typeof(RelayCommand), typeof(IceCreamList));

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