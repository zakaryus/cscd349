using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace cscd349FinalProject.Equipment
{
    class EquipmentGoldArmor : IEquipment
    {
        private string _description;
        private string _name;
        private HitPoint _hitpoints;
        private int _addHitPoints = 38;
        private Image _icon;

        public EquipmentGoldArmor()
        {

            Name = "Gold Armor";
            Description = "An armor that will protect you";
            Icon = new Image();
            ImageBrush myBrush = HelperImages.UriStringToImageBrush("pack://application:,,,/Equipment Icons/A_Armour03.png");
            Icon.Source = myBrush.ImageSource;
            HitPoints = new HitPoint(38);

        }

        public Image Icon
        {
            get { return _icon; }
            private set { _icon = value; }
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

        public HitPoint UseEquipment()
        {
            return new HitPoint(_addHitPoints);
        }
    }
}
