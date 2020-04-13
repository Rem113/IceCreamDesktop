using IceCreamDesktop.Core.Entities;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace IceCreamDesktop.Presentation.Views.Controls
{
	/// <summary>
	/// Interaction logic for ProductListItemControl.xaml
	/// </summary>
	public partial class ProductListItemControl : UserControl
	{
		public List<Product> Products
		{
			get { return (List<Product>)GetValue(ProductsProperty); }
			set { SetValue(ProductsProperty, value); }
		}

		public static readonly DependencyProperty ProductsProperty =
			DependencyProperty.Register("Products", typeof(List<Product>), typeof(ProductListItemControl));

		public ProductListItemControl()
		{
			InitializeComponent();
		}
	}
}