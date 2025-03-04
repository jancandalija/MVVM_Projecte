using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMarcane2.viewmodel;

namespace MVVMarcane2.model
{
	public class Items
	{
		public static string TABLE_NAME = "Items";

		[Key]
		private int itemId;
		private string name;
		private int rarity;
		private int iLevel;
		private string type;
		private int requeriment;
		private bool isFromQuest;
		private int dropChance;
		private string dropPlace;
		private string dropNPC;
		private string description;
		private string extras;
		private int strength;
		private int attackPower;
		private int stamina;
		private int agility;
		private int intellect;
		private int spirit;
		private int hit;
		private int spellPower;
		private int spellHealing;
		private int natureResistance;
		private int fireResistance;
		private int frostResistance;
		private int shadowResistance;
		private string urlWowhead;
		private DateTime? _dataAlta;
		private DateTime? _dataModificacio;



		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ItemId { get; set; }

		public string Name { get { return name; } set { name = value; } }
		public int Rarity { get { return rarity; } set { rarity = value; } }
		public int ILevel { get { return iLevel; } set { iLevel = value; } }
		public string Type { get { return type; } set { type = value; } }
		public int Requeriment { get { return requeriment; } set { requeriment = value; } }
		public bool IsFromQuest { get { return isFromQuest; } set { isFromQuest = value; } }
		public int DropChance { get { return dropChance; } set { dropChance = value; } }
		public string DropPlace { get { return dropPlace; } set { dropPlace = value; } }
		public string DropNPC { get { return dropNPC; } set { dropNPC = value; } }
		public string Description { get { return description; } set { description = value; } }
		public string Extras { get { return extras; } set { extras = value; } }
		public int Strength { get { return strength; } set { strength = value; } }
		public int AttackPower { get { return attackPower; } set { attackPower = value; } }
		public int Stamina { get { return stamina; } set { stamina = value; } }
		public int Agility { get { return agility; } set { agility = value; } }
		public int Intellect { get { return intellect; } set { intellect = value; } }
		public int Spirit { get { return spirit; } set { spirit = value; } }
		public int Hit { get { return hit; } set { hit = value; } }
		public int SpellPower { get { return spellPower; } set { spellPower = value; } }
		public int SpellHealing { get { return spellHealing; } set { spellHealing = value; } }
		public int NatureResistance { get { return natureResistance; } set { natureResistance = value; } }
		public int FireResistance { get { return fireResistance; } set { fireResistance = value; } }
		public int FrostResistance { get { return frostResistance; } set { frostResistance = value; } }
		public int ShadowResistance { get { return shadowResistance; } set { shadowResistance = value; } }
		public string UrlWowhead { get { return urlWowhead; } set { urlWowhead = value; } }
		public DateTime? dataAlta { get { return _dataAlta; } set { _dataAlta = value; } }
		public DateTime? dataModificacio { get { return _dataModificacio; } set { _dataModificacio = value; } }

		[Timestamp]
		public byte[] RowVersion { get; set; }
	}
}
