﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace cscd349FinalProject
{
    public interface ICharacter
    {
        //Properties
        string Name { get; }
        string Description { get; }
        HitPoint HitPoints { get; set; }
        HitPoint MaxHitPoints { get; set; }
        IWeapon Weapon { get; set; }
        List<IEquipment> Equipment { get; set; }
        Image Face { get; }

        //Methods
        HitPoint Attack();
        void Die();
    }
}
