using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMarcane2.model
{
	public class ItemsFiltre
	{
		public string sql = "";

		bool checkHead = false;
		bool checkNeck = false;
		bool checkCloak = false;
		bool checkChest = false;
		bool checkWrist = false;
		bool checkHands = false;
		bool checkWaist = false;
		bool checkLegs = false;
		bool checkFeet = false;
		bool checkRing = false;
		bool checkTrinket = false;
		bool checkShirt = false;

		bool checkCloth = false;
		bool checkLeather = false;
		bool checkMail = false;
		bool checkPlate = false;

		bool checkOneHandedSword = false;
		bool checkOneHandedAxe = false;
		bool checkOneHandedMace = false;
		bool checkTwoHandedSword = false;
		bool checkTwoHandedAxe = false;
		bool checkTwoHandedMace = false;
		bool checkStave = false;
		bool checkDagger = false;
		bool checkFistWeapon = false;
		bool checkPolearm = false;
		bool checkBow = false;
		bool checkCrossbow = false;
		bool checkGun = false;
		bool checkWand = false;
		bool checkThrown = false;
		bool checkMiscellaneous = false;

		bool checkQuest = false;
		bool checkConsumible = false;
		bool checkMaterial = false;
		bool checkTabard = false;
		bool checkOther = false;

		public ItemsFiltre(
			bool checkHead,
			bool checkNeck,
			bool checkCloak,
			bool checkChest,
			bool checkWrist,
			bool checkHands,
			bool checkWaist,
			bool checkLegs,
			bool checkFeet,
			bool checkRing,
			bool checkTrinket,
			bool checkShirt,

			bool checkCloth,
			bool checkLeather,
			bool checkMail,
			bool checkPlate,

			bool checkOneHandedSword,
			bool checkOneHandedAxe,
			bool checkOneHandedMace,
			bool checkTwoHandedSword,
			bool checkTwoHandedAxe,
			bool checkTwoHandedMace,
			bool checkStave,
			bool checkDagger,
			bool checkFistWeapon,
			bool checkPolearm,
			bool checkBow,
			bool checkCrossbow,
			bool checkGun,
			bool checkWand,
			bool checkThrown,
			bool checkMiscellaneous,

			bool checkQuest,
			bool checkConsumible,
			bool checkMaterial,
			bool checkTabard,
			bool checkOther
			)
		{
			this.checkHead = checkHead;
			this.checkNeck = checkNeck;
			this.checkCloak = checkCloak;
			this.checkChest = checkChest;
			this.checkWrist = checkWrist;
			this.checkHands = checkHands;
			this.checkWaist = checkWaist;
			this.checkLegs = checkLegs;
			this.checkFeet = checkFeet;
			this.checkRing = checkRing;
			this.checkTrinket = checkTrinket;
			this.checkShirt = checkShirt;

			this.checkCloth = checkCloth;
			this.checkLeather = checkLeather;
			this.checkMail = checkMail;
			this.checkPlate = checkPlate;

			this.checkOneHandedSword = checkOneHandedSword;
			this.checkOneHandedAxe = checkOneHandedAxe;
			this.checkOneHandedMace = checkOneHandedMace;
			this.checkTwoHandedSword = checkTwoHandedSword;
			this.checkTwoHandedAxe = checkTwoHandedAxe;
			this.checkTwoHandedMace = checkTwoHandedMace;
			this.checkStave = checkStave;
			this.checkDagger = checkDagger;
			this.checkFistWeapon = checkFistWeapon;
			this.checkPolearm = checkPolearm;
			this.checkBow = checkBow;
			this.checkCrossbow = checkCrossbow;
			this.checkGun = checkGun;
			this.checkWand = checkWand;
			this.checkThrown = checkThrown;
			this.checkMiscellaneous = checkMiscellaneous;

			this.checkQuest = checkQuest;
			this.checkConsumible = checkConsumible;
			this.checkMaterial = checkMaterial;
			this.checkTabard = checkTabard;
			this.checkOther = checkOther;

			build();
		}

		private ItemsFiltre build()
		{
			StringBuilder sql = new StringBuilder();
			sql.Append("SELECT * FROM " + Items.TABLE_NAME);

			List<string> conditions = new List<string>();

			if (checkHead) conditions.Add("Type = 'Head'");
			if (checkNeck) conditions.Add("Type = 'Neck'");
			if (checkCloak) conditions.Add("Type = 'Cloak'");
			if (checkChest) conditions.Add("Type = 'Chest'");
			if (checkWrist) conditions.Add("Type = 'Wrist'");
			if (checkHands) conditions.Add("Type = 'Hands'");
			if (checkWaist) conditions.Add("Type = 'Waist'");
			if (checkLegs) conditions.Add("Type = 'Legs'");
			if (checkFeet) conditions.Add("Type = 'Feet'");
			if (checkRing) conditions.Add("Type = 'Ring'");
			if (checkTrinket) conditions.Add("Type = 'Trinket'");
			if (checkShirt) conditions.Add("Type = 'Shirt'");

			if (checkCloth) conditions.Add("Type = 'Cloth'");
			if (checkLeather) conditions.Add("Type = 'Leather'");
			if (checkMail) conditions.Add("Type = 'Mail'");
			if (checkPlate) conditions.Add("Type = 'Plate'");

			if (checkOneHandedSword) conditions.Add("Type = 'One-Handed Sword'");
			if (checkOneHandedAxe) conditions.Add("Type = 'One-Handed Axe'");
			if (checkOneHandedMace) conditions.Add("Type = 'One-Handed Mace'");
			if (checkTwoHandedSword) conditions.Add("Type = 'Two-Handed Sword'");
			if (checkTwoHandedAxe) conditions.Add("Type = 'Two-Handed Axe'");
			if (checkTwoHandedMace) conditions.Add("Type = 'Two-Handed Mace'");
			if (checkStave) conditions.Add("Type = 'Stave'");
			if (checkDagger) conditions.Add("Type = 'Dagger'");
			if (checkFistWeapon) conditions.Add("Type = 'Fist Weapon'");
			if (checkPolearm) conditions.Add("Type = 'Polearm'");
			if (checkBow) conditions.Add("Type = 'Bow'");
			if (checkCrossbow) conditions.Add("Type = 'Crossbow'");
			if (checkGun) conditions.Add("Type = 'Gun'");
			if (checkWand) conditions.Add("Type = 'Wand'");
			if (checkThrown) conditions.Add("Type = 'Thrown'");
			if (checkMiscellaneous) conditions.Add("Type = 'Miscellaneous'");

			if (checkQuest) conditions.Add("Type = 'Quest'");
			if (checkConsumible) conditions.Add("Type = 'Consumible'");
			if (checkMaterial) conditions.Add("Type = 'Material'");
			if (checkTabard) conditions.Add("Type = 'Tabard'");
			if (checkOther) conditions.Add("Type = 'Other'");

			if (conditions.Count > 0)
			{
				sql.Append(" WHERE ");
				sql.Append(string.Join(" OR ", conditions));
			}

			this.sql = sql.ToString();
			return this;
		}

		public void clear()
		{
			this.sql = "";
		}
	}
}
