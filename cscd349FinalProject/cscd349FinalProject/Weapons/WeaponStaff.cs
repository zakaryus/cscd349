using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject.Weapons
{
    class WeaponStaff: IWeapon
    {
        public WeaponStaff(int minDamage, int maxDamage, string name)
        {
            minDamage = 20;
            maxDamage = 55;
            name = "Staff";
        }
    }
}
