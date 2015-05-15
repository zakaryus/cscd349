using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject.Weapons
{
    class WeaponNunchucks : IWeapon
    {

        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private string _description;
        private HitPoint _hitpoints;

        public WeaponNunchucks()
        {
            _minDamage = 35;
            _maxDamage = 65;
            _name = "Nunchucks";
        }

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

        public HitPoint UseWeapon()
        {
            Random rand = new Random();
            int val = rand.Next(_minDamage, _maxDamage+1);

            return new HitPoint(val);
        }
    }
}
