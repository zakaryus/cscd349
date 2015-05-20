using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace cscd349FinalProject.Weapons
{
    class WeaponElfBow : IWeapon
    {
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private string _description;
        private Image _icon;
        private HitPoint _hitpoints;

        public WeaponElfBow()
        {
            _minDamage = 20;
            _maxDamage = 85;
            Name = "Bow and Arrow";
            Description = "An excellent long range weapon. Mostly uneffective in close combat. This weapon requires a decent amout of skill to be used accurately.";
            Icon = new Image();
            ImageBrush myBrush = HelperImages.UriStringToImageBrush("pack://application:,,,/Weapon Icons/S_Bow13.png");
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
