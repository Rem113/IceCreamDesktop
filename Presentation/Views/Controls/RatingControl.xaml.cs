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