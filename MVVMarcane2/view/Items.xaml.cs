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
using MVVMarcane2.viewmodel;

namespace MVVMarcane2.view
{
	/// <summary>
	/// Lógica de interacción para Items.xaml
	/// </summary>
	public partial class Items : UserControl
	{
		public Items()
		{
			InitializeComponent();

			TaulerItems.ItemsSource = new ItemsVM().getItemsList();
		}
	}
}
