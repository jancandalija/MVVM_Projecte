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
					return Brushes.Gray; // Común
				case 1:
					return Brushes.White; // Común
				case 2:
					return Brushes.Green; // Poco común
				case 3:
					return Brushes.Blue; // Raro
				case 4:
					return Brushes.Purple; // Épico
				case 5:
					return Brushes.Orange; // Legendario
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
