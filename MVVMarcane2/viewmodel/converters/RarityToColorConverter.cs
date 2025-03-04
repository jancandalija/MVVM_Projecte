using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MVVMarcane2.viewmodel.converters
{
	public class RarityToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int rarity = (int)value;
			switch (rarity)
			{
				case 0:
					return "#9e9e9e"; // Gris
				case 1:
					return Brushes.White; // Común
				case 2:
					return "#1eff00"; // Poco común
				case 3:
					return "#0070dd"; // Raro
				case 4:
					return "#a334ed"; // Épico
				case 5:
					return "#ff8000"; // Legendario
				default:
					return Brushes.Black; // Desconocido
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
