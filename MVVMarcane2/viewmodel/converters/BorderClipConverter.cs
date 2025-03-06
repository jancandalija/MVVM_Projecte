using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MVVMarcane2.viewmodel.converters
{
	public class BorderClipConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is double width)
			{
				double borderThickness = 1; // Ajusta esto según el BorderThickness real o pásalo como parámetro
				return new Rect(borderThickness / 2, borderThickness / 2, width - borderThickness, width - borderThickness);
			}
			return new Rect(0, 0, 0, 0);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

