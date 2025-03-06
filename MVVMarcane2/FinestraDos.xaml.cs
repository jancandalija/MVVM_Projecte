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
using System.Windows.Shapes;

namespace MVVMarcane2
{
	/// <summary>
	/// Lógica de interacción para FinestraDos.xaml
	/// </summary>
	public partial class FinestraDos : Window
	{
		public FinestraDos()
		{
			InitializeComponent();
		}

		private void TancarApp_Click(object sender, RoutedEventArgs e)
		{
			LoginWindow loginWindow = new LoginWindow();
			FinestraDos mainWindow = new FinestraDos();
			loginWindow.Close();
			mainWindow.Close();
		}

		private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
				this.DragMove();
		}
	}
}
