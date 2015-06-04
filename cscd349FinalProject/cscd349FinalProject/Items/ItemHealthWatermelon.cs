using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace cscd349FinalProject.Items
{
    class ItemHealthWatermelon : IInventory
    {
        private string _description;
        private string _name;
        private HitPoint _hitpoints;
        private Image _icon;

        public ItemHealthWatermelon()
        {
           
            Name = "Yummy Melon";
            Description = "Water Water Water----MELON";
            Icon = new Image();
            ImageBrush myBrush = HelperImages.UriStringToImageBrush("pack://application:,,,/Item Icons/I_C_Watermellon.png");
            Icon.Source = myBrush.ImageSource;
            HitPoints = new HitPoint(150);
   
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
