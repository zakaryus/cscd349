using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace cscd349FinalProject.Weapons
{
    class WeaponStaff: IWeapon
    {

        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private string _description;
        private Image _icon;
        private HitPoint _hitpoints;

        public WeaponStaff()
        {
            _minDamage = 20;
            _maxDamage = 55;
            Name = "Staff";
            Description = "Good in close combat, but can prove unreliable against metal weapons.";
            Icon = new Image();
            ImageBrush myBrush = HelperImages.UriStringToImageBrush("pack://application:,,,/Weapon Icons/W_Mace008.png");
            Icon.Source = myBrush.ImageSource;
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

        public HitPoint UseWeapon()
        {
            Random rand = new Random();
            int val = rand.Next(_minDamage, _maxDamage + 1);

            return new HitPoint(val);
        }
    }
}
