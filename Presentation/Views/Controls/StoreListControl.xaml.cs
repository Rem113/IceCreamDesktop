using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Presentation.Common;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace IceCreamDesktop.Presentation.Views.Controls
{
	/// <summary>
	/// Interaction logic for StoreListControl.xaml
	/// </summary>
	public partial class StoreListControl : UserControl
	{
		public List<Store> Stores
		{
			get { return (List<Store>)GetValue(StoresProperty); }
			set { SetValue(StoresProperty, value); }
		}

		public static readonly DependencyProperty StoresProperty =
			DependencyProperty.Register("Stores", typeof(List<Store>), typeof(StoreListControl));

		public RelayCommand NavigateCommand
		{
			get { return (RelayCommand)GetValue(NavigateCommandProperty); }
			set { SetValue(NavigateCommandProperty, value); }
		}

		public static readonly DependencyProperty NavigateCommandProperty =
			DependencyProperty.Register("NavigateCommand", typeof(RelayCommand), typeof(StoreListControl));

		public StoreListControl()
		{
			InitializeComponent();
		}
	}
}