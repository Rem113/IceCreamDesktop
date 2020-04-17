using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;

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