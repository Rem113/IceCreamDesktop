using System.Windows;
using System.Windows.Controls;

namespace IceCreamDesktop.Presentation.Views.Controls
{
	/// <summary>
	/// Interaction logic for RatingControl.xaml
	/// </summary>
	public partial class RatingControl : UserControl
	{
		public int Rating
		{
			get { return (int)GetValue(RatingProperty); }
			set { SetValue(RatingProperty, value); }
		}

		public static readonly DependencyProperty RatingProperty =
			DependencyProperty.Register("Rating", typeof(int), typeof(RatingControl));

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(string), typeof(RatingControl));

		public RatingControl()
		{
			InitializeComponent();
		}
	}
}