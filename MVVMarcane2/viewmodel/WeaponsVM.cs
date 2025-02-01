using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMarcane2.model;

namespace MVVMarcane2.viewmodel
{
    internal class WeaponsVM : utilities.ViewModelBase
    {
        private const string WEAPON_ID = "weaponId";
        private const string WEAPON_NAME = "weaponName";
        private const string WEAPON_POWER = "weaponPower";
        private const string WEAPON_TYPE = "weaponType";

        private DataBaseConnection db;
        private Weapons weapons;

        public int WeaponID
        {
            get { return weapons.WeaponId; }
            set { weapons.WeaponId = value; OnProperyChanged(); }
        }

        public string WeaponName
        {
            get { return weapons.WeaponName; }
            set { weapons.WeaponName = value; OnProperyChanged(); }
        }

        public int WeaponPower
        {
            get { return weapons.WeaponPower; }
            set { weapons.WeaponPower = value; OnProperyChanged(); }
        }

        public string WeaponType
        {
            get { return weapons.WeaponType; }
            set { weapons.WeaponType = value; OnProperyChanged(); }
        }

        public WeaponsVM(int weaponId)
        {
            weapons = new Weapons();

            WeaponID = 0;
            WeaponName = "";
            WeaponPower = 0;
            WeaponType = "";

            if (weaponId > 0)
            {
                db = new DataBaseConnection();

                db.useSql(sqlCercaWeaponPerId());
                db.addWithValue("@" + WEAPON_ID, weaponId);
                db.fill();

                WeaponID = (int)db.getPrimerResultat(WEAPON_ID);
                WeaponName = (string)db.getPrimerResultat(WEAPON_NAME);
                WeaponPower = (int)db.getPrimerResultat(WEAPON_POWER);
                WeaponType = (string)db.getPrimerResultat(WEAPON_TYPE);
            }
        }

        private string sqlCercaWeaponPerId()
        {
            return "SELECT * FROM Weapons WHERE weaponId=@" + WEAPON_ID;
        }
    }
}
