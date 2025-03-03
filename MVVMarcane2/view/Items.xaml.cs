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
using MVVMarcane2.model;
using MVVMarcane2.viewmodel;

namespace MVVMarcane2.view
{
	/// <summary>
	/// Lógica de interacción para Items.xaml
	/// </summary>
	public partial class Items : UserControl
	{

		ItemsVM itemSeleccionat;

		public Items()
		{
			InitializeComponent();

			TaulerItems.ItemsSource = new ItemsVM().getItemsList();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// Click al botó FILTRAR

			

			ItemsFiltre itemsFiltre = new ItemsFiltre(
				(bool)checkHead.IsChecked,
				(bool)checkNeck.IsChecked,
				(bool)checkCloak.IsChecked,
				(bool)checkChest.IsChecked,
				(bool)checkWrist.IsChecked,
				(bool)checkHands.IsChecked,
				(bool)checkWaist.IsChecked,
				(bool)checkLegs.IsChecked,
				(bool)checkFeet.IsChecked,
				(bool)checkRing.IsChecked,
				(bool)checkTrinket.IsChecked,
				(bool)checkShirt.IsChecked,

				(bool)checkCloth.IsChecked,
				(bool)checkLeather.IsChecked,
				(bool)checkMail.IsChecked,
				(bool)checkPlate.IsChecked,

				(bool)checkOneHandedSword.IsChecked,
				(bool)checkOneHandedAxe.IsChecked,
				(bool)checkOneHandedMace.IsChecked,
				(bool)checkTwoHandedSword.IsChecked,
				(bool)checkTwoHandedAxe.IsChecked,
				(bool)checkTwoHandedMace.IsChecked,
				(bool)checkStave.IsChecked,
				(bool)checkDagger.IsChecked,
				(bool)checkFistWeapon.IsChecked,
				(bool)checkPolearm.IsChecked,
				(bool)checkBow.IsChecked,
				(bool)checkCrossbow.IsChecked,
				(bool)checkGun.IsChecked,
				(bool)checkWand.IsChecked,
				(bool)checkThrown.IsChecked,
				(bool)checkMiscellaneous.IsChecked,

				(bool)checkQuest.IsChecked,
				(bool)checkConsumible.IsChecked,
				(bool)checkMaterial.IsChecked,
				(bool)checkTabard.IsChecked,
				(bool)checkOther.IsChecked
			);

			TaulerItems.ItemsSource = new ItemsVM(itemsFiltre).getItemsList();

		}

		private void TaulerItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			itemSeleccionat = new ItemsVM(TaulerItems.SelectedItem as model.Items);
			if (itemSeleccionat != null)
			{
				TextBlockItemId.Text = itemSeleccionat.ItemId.ToString();
				TextBlockItemNom.Text = itemSeleccionat.Name;
			}
			
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{

		}
	}
}
