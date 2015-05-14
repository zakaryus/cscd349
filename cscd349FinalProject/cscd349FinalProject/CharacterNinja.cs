﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject
{
    class CharacterNinja: ICharacter
    {
        #region Fields
        private string _name;
        private string _description;
        private HitPoint _hitpoints;
        private IWeapon _weapon;
        private List<IEquipment> _equipment;
        private List<IInventory> _inventory;
        #endregion Fields

        #region Properties
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            private set { _description = value; }
        }

        public HitPoint HitPoints
        {
            get { return _hitpoints; }
            set { _hitpoints = value; }
        }

        public IWeapon Weapon
        {
            get { return _weapon; }
            set { _weapon = value; }
        }

        public List<IEquipment> Equipment
        {
            get { return _equipment; }
            set { _equipment = value; }
        }

        public List<IInventory> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        #endregion Properties

        #region Constructor

        public CharacterNinja()
        {
            Name = "Ninja";
            Description = "A sly, agile character.";
            HitPoints = new HitPoint(100);
            Weapon = null;
            Equipment = null;
            Inventory = null;
        }
        #endregion Constructor

        #region Methods
        public HitPoint Attack()
        {
            return _weapon.UseWeapon();
        }

        public void Die()
        {
            //I'm dead
            //do something
        }
        #endregion Methods
    }
}