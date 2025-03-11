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
using MVVMarcane2.viewmodel.converters;

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
			TaulerFiltresFav.ItemsSource = new FiltresVM(FiltresVM.MODE_OBTENIR_TOT).getFiltresList();
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
				TaulerItemsInfo.Visibility = Visibility.Visible;
				TaulerItemsInfoA.Visibility = Visibility.Visible;
				TaulerItemsInfoB.Visibility = Visibility.Visible;
				TaulerItemsInfoC.Visibility = Visibility.Visible;

				lbItemNom.Visibility = Visibility.Visible;
				lbItemNom.Content = itemSeleccionat.Name.ToString();
				lbItemNom.Foreground = obtenirColorFromRarity(itemSeleccionat.Rarity);

				switch (itemSeleccionat.Type)
				{
					case ItemType.ONE_HANDED_SWORD:
					case ItemType.ONE_HANDED_AXE:
					case ItemType.ONE_HANDED_MACE:
					case ItemType.TWO_HANDED_SWORD:
					case ItemType.TWO_HANDED_AXE:
					case ItemType.TWO_HANDED_MACE:
					case ItemType.STAVE:
					case ItemType.POLEARM:
					case ItemType.GUN	:
					case ItemType.BOW:
					case ItemType.CROSSBOW:
					case ItemType.DAGGER:
					case ItemType.FIST_WEAPON:
					case ItemType.THROWN:
					case ItemType.WAND:

						lbItemDamage.Visibility = Visibility.Visible;
						lbItemDamage.Content = itemSeleccionat.getWeaponDamage(itemSeleccionat.ItemId);

						break;
					default:
						break;
				}

			}
			else
			{
				TaulerItemsInfo.Visibility = Visibility.Collapsed;
				TaulerItemsInfoA.Visibility = Visibility.Collapsed;
				TaulerItemsInfoB.Visibility = Visibility.Collapsed;
				TaulerItemsInfoC.Visibility = Visibility.Collapsed;
			}

		}

		private Brush obtenirColorFromRarity(int rarity)
		{
			object color = RarityToColorConverter.ConvertNormal(rarity);

			if (color is string)
			{
				return (Brush)new BrushConverter().ConvertFromString((string)color);
			}
			else
			{
				return (Brush)color;
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			// Guardar filtre a favorits

			FiltresVM.createFiltre(
				tbFiltrarFiltresFavorits.Text.ToString(), 
				new ItemsFiltre(
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
					)
				.sql
				);

			TaulerFiltresFav.ItemsSource = new FiltresVM(FiltresVM.MODE_OBTENIR_TOT).getFiltresList();
		}
	}
}
