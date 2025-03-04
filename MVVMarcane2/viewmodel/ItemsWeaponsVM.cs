using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMarcane2.model;
using MVVMarcane2.view;

namespace MVVMarcane2.viewmodel
{
	public class ItemsWeaponsVM : utilities.ViewModelBase
	{
		private const string WEAPON_ID = "weaponId";
		private const string ITEM_ID = "itemId";
		private const string DAMAGE_LOWEST = "damageLowest";
		private const string DAMAGE_HIGHEST = "damageHighest";

		private DataBaseConnectionMySQL db;
		private ItemsWeapons itemWeapon;

		public int WeaponId { get { return itemWeapon.ItemId; } set { itemWeapon.ItemId = value; OnProperyChanged(); } }
		public int ItemId { get { return itemWeapon.ItemId; } set { itemWeapon.ItemId = value; OnProperyChanged(); } }
		public int DamageLowest { get { return itemWeapon.DamageLowest; } set { itemWeapon.DamageLowest = value; OnProperyChanged(); } }
		public int DamageHighest { get { return itemWeapon.DamageHighest; } set { itemWeapon.DamageHighest = value; OnProperyChanged(); } }

		public ItemsWeaponsVM(int itemId)
		{
			itemWeapon = new ItemsWeapons();

			WeaponId = 0;
			ItemId = 0;
			DamageLowest = 0;
			DamageHighest = 0;

			if (itemId > 0)
			{
				db = new DataBaseConnectionMySQL();

				db.useSql(sqlGetByItemId());
				db.addWithValue("@" + ITEM_ID, itemId);
				db.fill();
				try
				{
					WeaponId = (int)db.getPrimerResultat(WEAPON_ID);
					ItemId = (int)db.getPrimerResultat(ITEM_ID);
					DamageLowest = (int)db.getPrimerResultat(DAMAGE_LOWEST);
					DamageHighest = (int)db.getPrimerResultat(DAMAGE_HIGHEST);
				}
				catch (Exception e)
				{
					WeaponId = 0;
					ItemId = 0;
					DamageLowest = 0;
					DamageHighest = 0;
				}
			}
		}

		private string sqlGetByItemId()
		{
			return "SELECT * FROM ItemsWeapons WHERE ItemId=@" + ITEM_ID;
		}
	}
}
