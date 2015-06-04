using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace cscd349FinalProject.Items
{
    class ItemHealthBread : IInventory
    {
        private string _description;
        private string _name;
        private HitPoint _hitpoints;
        private Image _icon;

        public ItemHealthBread() 
        {
           
            Name = "Bread";
            Description = "Bread for the weak";
            Icon = new Image();
            ImageBrush myBrush = HelperImages.UriStringToImageBrush("pack://application:,,,/Item Icons/Item_Bread.png");
            Icon.Source = myBrush.ImageSource;
            HitPoints = new HitPoint(35);
   
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
            return HitPoints;
        }
    }
}
