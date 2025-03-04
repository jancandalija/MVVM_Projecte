using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Notice.Warning.Types;
using System.Xml.Linq;
using MVVMarcane2.viewmodel;

namespace MVVMarcane2.model
{
	public class ItemsWeapons
	{
		[Key]
		private int weaponId;
		private int itemId;
		private int damageLowest;
		private int damageHighest;

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int WeaponId { get; set; }

		public int ItemId { get { return itemId; } set { itemId = value; } }
		public int DamageLowest { get { return damageLowest; } set { damageLowest = value; } }
		public int DamageHighest { get { return damageHighest; } set { damageHighest = value; } }
		
	}
}
