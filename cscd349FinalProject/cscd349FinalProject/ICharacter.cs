﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject
{
    interface ICharacter
    {
        //Properties
        string Name { get; }
        string Description { get; }
        HitPoint HitPoints { get; set; }
        IWeapon Weapon { get; set; }
        List<IEquipment> Equipment { get; set; }
        List<IInventory> Inventory { get; set; } 

        //Methods
        HitPoint Attack();
        void Die();
    }
}
