using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject.Weapons
{
    class WeaponNunchucks : IWeapon
    {
        public WeaponNunchucks(int minDamage, int maxDamage, string name)
        {
            minDamage = 35;
            maxDamage = 65;
            name = "Nunchucks";
        }
    }
}
