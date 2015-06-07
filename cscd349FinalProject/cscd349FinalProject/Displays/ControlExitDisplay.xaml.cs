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
    /// <summary>
    /// Interaction logic for ControlExitDisplay.xaml
    /// </summary>
    

    public partial class ControlExitDisplay : UserControl
    {
        private IItem _exit;
   
        public IItem Exit { get; set; }
   
        public ControlExitDisplay()
        {
            InitializeComponent();
            Exit = _exit;
            imgExitDisplay.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Item Icons/door.png");
            


        }
    }
}
