using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject.Weapons
{
    class WeaponSword : IWeapon
    {
        public WeaponSword(int minDamage, int maxDamage, string name)
        {
            minDamage = 55;
            maxDamage = 75;
            name = "Sword";
        }
    }
}
