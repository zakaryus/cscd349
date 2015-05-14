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

namespace cscd349FinalProject
{
    /// <summary>
    /// Interaction logic for ControlCharacter.xaml
    /// </summary>
    public partial class ControlCharacter : UserControl
    {
        private const int finalCheckCount = 3;
        private int curCheckCount;

        public ControlCharacter()
        {
            InitializeComponent();
            curCheckCount = 0;
        }

        private void cb_Checked(object sender, RoutedEventArgs e)
        {
            curCheckCount++;
            EnablePlay();
        }

        private void cb_Unchecked(object sender, RoutedEventArgs e)
        {
            curCheckCount--;
            EnablePlay();
        }

        private void EnablePlay()
        {
            if (curCheckCount == finalCheckCount)
                btnPlay.IsEnabled = true;
            else
                btnPlay.IsEnabled = false;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().ChangeScene(Scene.GamePlay);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().ChangeScene(Scene.Main);
        }
    }
}
