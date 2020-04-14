using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Presentation.ViewModels.Commands;
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