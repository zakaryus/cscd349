using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject.Characters
{
    class ACharacterPlayer: ACharacter
    {

        public sealed override HitPoint Attack()
        {
            return Weapon.UseWeapon();
        }
    }
}
