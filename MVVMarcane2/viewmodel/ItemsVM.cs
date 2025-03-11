using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MVVMarcane2.model;
using static Mysqlx.Notice.Warning.Types;
using System.IO.Ports;
using System.Xml.Linq;
using System.Data;

namespace MVVMarcane2.viewmodel
{
	public class ItemsVM : utilities.ViewModelBase
	{
		private DataBaseConnectionMySQL db;
		private Items items;
		private List<Items> itemsList;

		public int ItemId { get { return items.ItemId; } set { items.ItemId = value; OnProperyChanged(); } }
		public string Name { get { return items.Name; } set { items.Name = value; OnProperyChanged(); } }
		public int Rarity { get { return items.Rarity; } set { items.Rarity = value; OnProperyChanged(); } }
		public int ILevel { get { return items.ILevel; } set { items.ILevel = value; OnProperyChanged(); } }
		public string Type { get { return items.Type; } set { items.Type = value; OnProperyChanged(); } }
		public int Requeriment { get { return items.Requeriment; } set { items.Requeriment = value; OnProperyChanged(); } }
		public bool IsFromQuest { get { return items.IsFromQuest; } set { items.IsFromQuest = value; OnProperyChanged(); } }
		public int DropChance { get { return items.DropChance; } set { items.DropChance = value; OnProperyChanged(); } }
		public string DropPlace { get { return items.DropPlace; } set { items.DropPlace = value; OnProperyChanged(); } }
		public string DropNPC { get { return items.DropNPC; } set { items.DropNPC = value; OnProperyChanged(); } }
		public string Description { get { return items.Description; } set { items.Description = value; OnProperyChanged(); } }
		public string Extras { get { return items.Extras; } set { items.Extras = value; OnProperyChanged(); } }
		public int Strength { get { return items.Strength; } set { items.Strength = value; OnProperyChanged(); } }
		public int AttackPower { get { return items.AttackPower; } set { items.AttackPower = value; OnProperyChanged(); } }
		public int Stamina { get { return items.Stamina; } set { items.Stamina = value; OnProperyChanged(); } }
		public int Agility { get { return items.Agility; } set { items.Agility = value; OnProperyChanged(); } }
		public int Intellect { get { return items.Intellect; } set { items.Intellect = value; OnProperyChanged(); } }
		public int Spirit { get { return items.Spirit; } set { items.Spirit = value; OnProperyChanged(); } }
		public int Hit { get { return items.Hit; } set { items.Hit = value; OnProperyChanged(); } }
		public int SpellPower { get { return items.SpellPower; } set { items.SpellPower = value; OnProperyChanged(); } }
		public int SpellHealing { get { return items.SpellHealing; } set { items.SpellHealing = value; OnProperyChanged(); } }
		public int NatureResistance { get { return items.NatureResistance; } set { items.NatureResistance = value; OnProperyChanged(); } }
		public int FireResistance { get { return items.FireResistance; } set { items.FireResistance = value; OnProperyChanged(); } }
		public int FrostResistance { get { return items.FrostResistance; } set { items.FrostResistance = value; OnProperyChanged(); } }
		public int ShadowResistance { get { return items.ShadowResistance; } set { items.ShadowResistance = value; OnProperyChanged(); } }
		public string UrlWowhead { get { return items.UrlWowhead; } set { items.UrlWowhead = value; OnProperyChanged(); } }
		public DateTime? dataAlta { get { return items.dataAlta; } set { items.dataAlta = value; OnProperyChanged(); } }
		public DateTime? dataModificacio { get { return items.dataModificacio; } set { items.dataModificacio = value; OnProperyChanged(); } }

		public ItemsVM()
		{
			items = new Items();
			itemsList = new List<Items>();

			db = new DataBaseConnectionMySQL();

			db.useSql(sqlGetAll());
			db.fill();

			foreach (DataRow row in db.getData().Rows)
			{
				Items item = new Items
				{
					ItemId = (int)row["ItemId"],
					Rarity = (int)row["Rarity"],
					Name = (string)row["Name"],
					ILevel = (int)row["ILevel"],
					Requeriment = (int)row["Requeriment"],
					Type = (string)row["Type"],
				};
				itemsList.Add(item);
			}
		}


		public ItemsVM(ItemsFiltre itemsFiltre)
		{
			items = new Items();
			itemsList = new List<Items>();

			db = new DataBaseConnectionMySQL();

			db.useSql(itemsFiltre.sql); // TODO: S'ha de fer el mateix a Filtres, però utilitzar un filtre temporal, per no perdre l'actual seleccionat o bé substituir i adaptar tots els checks pel del filtre fav
			db.fill();

			foreach (DataRow row in db.getData().Rows)
			{
				Items item = new Items
				{
					ItemId = (int)row["ItemId"],
					Rarity = (int)row["Rarity"],
					Name = (string)row["Name"],
					ILevel = (int)row["ILevel"],
					Requeriment = (int)row["Requeriment"],
					Type = (string)row["Type"],
				};
				itemsList.Add(item);
			}
		}


		public ItemsVM(model.Items item)
		{
			items = new Items();
			this.ItemId = item.ItemId;
			this.Name = item.Name;
			this.Type = item.Type;
			this.Rarity = item.Rarity;
		}

		public List<Items> getItemsList()
		{
			return itemsList;
		}

		private string sqlGetAll()
		{
			return "SELECT * FROM Items";
		}

		public int getId()
		{
			return ItemId;
		}

		public string getWeaponDamage(int itemId)
		{
			string resultat = "";

			ItemsWeaponsVM weapon = new ItemsWeaponsVM(itemId);

			resultat += weapon.DamageLowest + " - " + weapon.DamageHighest;

			return resultat;
		}

	}
}
