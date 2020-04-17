using IceCreamDesktop.Core.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace IceCreamDesktop.Presentation.Converters
{
	public class RatingToIntConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (int)(Ratings)value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (Ratings)(int)value;
		}
	}
}