using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace cscd349FinalProject.Items
{
    class ItemHealthPotionBig : IInventory
    {
        private string _description;
        private string _name;
        private HitPoint _hitpoints;
        private int _addHitPoints = 100;
        private Image _icon;

        public ItemHealthPotionBig()
        {
           
            Name = "Powerful Potion";
            Description = "A powerful potion that will help you cheat death";
            Icon = new Image();
            ImageBrush myBrush = HelperImages.UriStringToImageBrush("pack://application:,,,/Item Icons/P_Green01.png");
            Icon.Source = myBrush.ImageSource;
   
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

        public HitPoint UseInventory()
        {
            return new HitPoint(_addHitPoints);
        }
    }
}
