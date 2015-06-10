using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cscd349FinalProject.Weapons;

namespace cscd349FinalProject
{
    class WeaponManager
    {
        private static WeaponManager _instance;
        private static List<IWeapon> _allWeapons;

        public List<IWeapon> AllWeapons
        {
            get { return _allWeapons; }
            private set { _allWeapons = value; }
        }

        public static WeaponManager GetInstance()
        {
            if(_instance == null)
                _instance = new WeaponManager();

            return _instance;
        }

        private WeaponManager()
        {
            AllWeapons = new List<IWeapon>
                         {
                             new WeaponElfBow(),
                             new WeaponHeavySword(),
                             new WeaponIronBallMace(),
                             new WeaponStaff(),
                             new WeaponSword()
                         };
        }
    }
}
