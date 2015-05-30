using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cscd349FinalProject.Displays
{
    public enum TileType { Floor, Wall };

    /// <summary>
    /// Interaction logic for ControlGridTile.xaml
    /// </summary>
    public partial class ControlGridTile : UserControl
    {
        public bool Occupiable { get; private set; }

        public ControlGridTile(TileType type)
        {
            InitializeComponent();

            Occupiable = type == TileType.Wall ? false : true;

            if(type == TileType.Wall)
            {
                Occupiable = false;
                Background = HelperImages.UriStringToImageBrush("pack://application:,,,/Images/Backgrounds/brick.png");
            }
            else if (type == TileType.Floor)
            {
                Occupiable = true;
                Background = HelperImages.UriStringToImageBrush("pack://application:,,,/Images/Backgrounds/grass.png");
            }
        }
    }
}
