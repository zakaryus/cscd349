﻿using System;
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
    /// Interaction logic for ControlGamePlay.xaml
    /// </summary>
    public partial class ControlGamePlay : UserControl
    {
        public ControlGamePlay()
        {
            InitializeComponent();

            //battleGround.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "cscd349FinalProject/images/backgrounds/bg1.png")));
           // ImageSource 
           
            battleGround.Background = HelperImages.UriStringToImageBrush("pack://application:,,,/Images/Backgrounds/bg1.jpg");

        }

        private void btnBattle_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().ChangeScene(Scene.Battle);
        }

        private void btnWin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().ChangeScene(Scene.Win);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().ChangeScene(Scene.Character);
        }
    }
}
