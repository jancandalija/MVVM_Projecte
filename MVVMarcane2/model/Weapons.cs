using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMarcane2.model
{
    internal class Weapons
    {
        private int weaponId;
        private string weaponName;
        private int weaponPower;
        private string weaponType;

        public int WeaponId { get { return weaponId; } set { weaponId = value; } }
        public string WeaponName { get { return weaponName; } set { weaponName = value; } }
        public int WeaponPower { get { return weaponPower; } set { weaponPower = value; } }
        public string WeaponType { get { return weaponType; } set { weaponType = value; } }
    }
}
