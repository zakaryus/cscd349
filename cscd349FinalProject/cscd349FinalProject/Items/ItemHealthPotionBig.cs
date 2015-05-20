using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace cscd349FinalProject.Items
{
    class ItemHealthPotionBig : IInventory
    {
        private string _description;
        private string _name;
        private HitPoint _hitpoints;
        private Image _icon;
        private int _addHitPoints = 100;

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

        public Image Icon
        {
            get { return _icon; }
            private set { _icon = value; }
        }

        public HitPoint UseInventory()
        {
            return new HitPoint(_addHitPoints);
        }
    }
}
