using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace cscd349FinalProject.Weapons
{
    class WeaponSword : IWeapon
    {
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private string _description;
        private Image _icon;
        private HitPoint _hitpoints;

        public WeaponSword()
        {
            _minDamage = 55;
            _maxDamage = 75;
            Name = "Sword";
            Description = "A fast weapon, excellent in close combat.";
            Icon = new Image();
            ImageBrush myBrush = HelperImages.UriStringToImageBrush("pack://application:,,,/Weapon Icons/W_Sword008.png");
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
