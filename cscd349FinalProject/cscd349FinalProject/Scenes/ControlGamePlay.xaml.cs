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
    /// Interaction logic for ControlGamePlay.xaml
    /// </summary>
    public partial class ControlGamePlay : UserControl
    {
        private UserControl ally;
        private Point allyPosition;

        public ControlGamePlay()
        {
            InitializeComponent();

            Random r = new Random();
            int enemyNum = 0;
            for (int i = 0; i < grdBattleGround.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < grdBattleGround.ColumnDefinitions.Count; j++)
                {
                    Image img = new Image();
                    img.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Images/Backgrounds/grass.png");
                    img.SetValue(Grid.ColumnProperty, j);
                    img.SetValue(Grid.RowProperty, i);
                    img.Stretch = Stretch.UniformToFill;
                    grdBattleGround.Children.Add(img);
                    
                    int n = r.Next();
                    Console.WriteLine(n);
                    if (n % 43 == 0)
                    {
                        UserControl uc = new UserControl();
                        uc.Content = enemyNum++.ToString();
                        Grid.SetColumn(uc, j);
                        Grid.SetRow(uc, i);
                        grdBattleGround.Children.Add(uc);
                    }
                }
            }

            allyPosition = new Point(0, 0);
            ally = new UserControl();
            ally.Content = "x";
            Grid.SetColumn(ally, (int)allyPosition.X);
            Grid.SetRow(ally, (int)allyPosition.Y);
            grdBattleGround.Children.Add(ally);

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

        private void grdBattleGround_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.W)
            {
                allyPosition.Y -= allyPosition.Y == 0 ? 0 : 1;
                Grid.SetColumn(ally, (int)allyPosition.X);
                Grid.SetRow(ally, (int)allyPosition.Y);
            }
            else if (e.Key == Key.Down || e.Key == Key.S)
            {
                allyPosition.Y += allyPosition.Y == grdBattleGround.RowDefinitions.Count - 1 ? 0 : 1;
                Grid.SetColumn(ally, (int)allyPosition.X);
                Grid.SetRow(ally, (int)allyPosition.Y);
            }
            else if (e.Key == Key.Left || e.Key == Key.A)
            {
                allyPosition.X -= allyPosition.X == 0 ? 0 : 1;
                Grid.SetColumn(ally, (int)allyPosition.X);
                Grid.SetRow(ally, (int)allyPosition.Y);
            }
            else if (e.Key == Key.Right || e.Key == Key.D)
            {
                allyPosition.X += allyPosition.X == grdBattleGround.ColumnDefinitions.Count - 1 ? 0 : 1;
                Grid.SetColumn(ally, (int)allyPosition.X);
                Grid.SetRow(ally, (int)allyPosition.Y);
            }

            var children = grdBattleGround.Children.Cast<UIElement>().ToList();
            UserControl enemy = null;

            foreach(var child in children)
            {
                if(Grid.GetRow(child) == allyPosition.Y && Grid.GetColumn(child) == allyPosition.X && child != ally)
                {
                    try
                    {
                        enemy = child as UserControl;
                    }
                    catch(InvalidCastException ex)
                    {
                        Console.WriteLine(ex.Message);
                        enemy = null;
                    }
                }
            }

            if(enemy != null && enemy != ally)
            {
                var res = MessageBox.Show("Enemy " + enemy.Content + " encountered!", "Battle", MessageBoxButton.OK);
                if (res == MessageBoxResult.OK)
                {
                    grdBattleGround.Children.Remove(enemy);
                    MainWindow.GetInstance().ChangeScene(Scene.Battle);
                }
            }

            InvalidateVisual();
            grdBattleGround.Focus();
        }

        private void grdBattleGround_Loaded(object sender, RoutedEventArgs e)
        {
            grdBattleGround.Focus();
        }
    }
}
