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
	public partial class ProductListControl : UserControl
	{
		public RelayCommand NavigateCommand
		{
			get { return (RelayCommand)GetValue(NavigateCommandProperty); }
			set { SetValue(NavigateCommandProperty, value); }
		}

		public static readonly DependencyProperty NavigateCommandProperty =
			DependencyProperty.Register("NavigateCommand", typeof(RelayCommand), typeof(ProductListControl));

		public List<Product> Products
		{
			get { return (List<Product>)GetValue(ProductsProperty); }
			set { SetValue(ProductsProperty, value); }
		}

		public static readonly DependencyProperty ProductsProperty =
			DependencyProperty.Register("Products", typeof(List<Product>), typeof(ProductListControl));

		public ProductListControl()
		{
			InitializeComponent();
		}
	}
}