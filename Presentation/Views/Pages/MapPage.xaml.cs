using Microsoft.Maps.MapControl.WPF;
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

namespace IceCreamDesktop.Presentation.Views.Pages
{
	/// <summary>
	/// Interaction logic for MapPage.xaml
	/// </summary>
	public partial class MapPage : UserControl
	{
		public MapPage()
		{
			InitializeComponent();
		}
	}

	public static class MapHelper
	{
		public static readonly DependencyProperty CenterProperty
			= DependencyProperty.RegisterAttached(
				"Center",
				typeof(Location),
				typeof(MapHelper),
				new PropertyMetadata(
					new Location(0.0, 0.0),
					new PropertyChangedCallback(CenterChanged)
				)
			);

		public static void SetCenter(DependencyObject obj, Location value)
		{
			obj.SetValue(CenterProperty, value);
		}

		public static Location GetCenter(DependencyObject obj)
		{
			return (Location)obj.GetValue(CenterProperty);
		}

		private static void CenterChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			Map map = (Map)obj;
			if (map != null)
				map.Center = (Location)args.NewValue;
		}
	}
}