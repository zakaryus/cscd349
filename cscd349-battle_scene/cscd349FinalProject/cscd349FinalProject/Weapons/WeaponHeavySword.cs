using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject.Weapons
{
    class WeaponHeavySword :IWeapon
    {
        public WeaponHeavySword(int minDamage, int maxDamage, string name)
        {
            minDamage = 75;
            maxDamage = 100;
            name = "Heavy Sword";
        }
    }
}
