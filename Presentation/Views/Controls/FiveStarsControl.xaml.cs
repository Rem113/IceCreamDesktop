using MaterialDesignThemes.Wpf;
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

namespace IceCreamDesktop.Presentation.Views.Controls
{
	/// <summary>
	/// Interaction logic for FiveStarsControl.xaml
	/// </summary>
	public partial class FiveStarsControl : UserControl
	{
		public int Count
		{
			get { return (int)GetValue(CountProperty); }
			set { SetValue(CountProperty, value); }
		}

		public static readonly DependencyProperty CountProperty =
			DependencyProperty.Register("Count", typeof(int), typeof(FiveStarsControl), new PropertyMetadata(5, OnCountChanged));

		private static void OnCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var control = d as FiveStarsControl;
			var value = (int)e.NewValue;

			for (int i = 0; i < 5; ++i)
			{
				var star = control.Container.Children[i] as PackIcon;
				star.Kind = i < value ? PackIconKind.Star : PackIconKind.StarBorder;
			}
		}

		public FiveStarsControl()
		{
			InitializeComponent();
		}
	}
}