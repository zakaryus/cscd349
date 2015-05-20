using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace cscd349FinalProject.Equipment
{
    class EquipmentNull: IEquipment
    {
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private string _description;
        private Image _icon;
        private HitPoint _hitpoints;

        public EquipmentNull()
        {
            _minDamage = 0;
            _maxDamage = 0;
            Name = String.Empty;
            Description = String.Empty;
            Icon = new Image();
            HitPoints = new HitPoint((_maxDamage + _minDamage) / 2);
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

        public Image Icon
        {
            get { return _icon; }
            private set { _icon = value; }
        }

        public HitPoint HitPoints
        {
            get { return _hitpoints; }
            private set { _hitpoints = value; }
        }

        public HitPoint UseEquipment()
        {
            Random rand = new Random();
            int val = rand.Next(_minDamage, _maxDamage + 1);

            return new HitPoint(val);
        }
    }
}
