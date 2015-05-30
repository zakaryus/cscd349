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
using cscd349FinalProject.Displays;

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
                    //Image img = new Image();
                    //img.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Images/Backgrounds/grass.png");
                    //img.SetValue(Grid.ColumnProperty, j);
                    //img.SetValue(Grid.RowProperty, i);
                    //img.Stretch = Stretch.UniformToFill;
                    //grdBattleGround.Children.Add(img);
                    
                    int n = r.Next();

                    if(i != 0 && j != 0)
                    {
                        TileType type = n % 2 == 0 ? TileType.Floor : TileType.Wall;
                        ControlGridTile gt = new ControlGridTile(type);
                        Grid.SetColumn(gt, j);
                        Grid.SetRow(gt, i);
                        grdBattleGround.Children.Add(gt);
                    }
                    else
                    {
                        TileType type = TileType.Floor;
                        ControlGridTile gt = new ControlGridTile(type);
                        Grid.SetColumn(gt, j);
                        Grid.SetRow(gt, i);
                        grdBattleGround.Children.Add(gt);
                    }

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
            int tmpX = (int)allyPosition.X;
            int tmpY = (int)allyPosition.Y;

            if (e.Key == Key.Up || e.Key == Key.W)
            {
                tmpY -= allyPosition.Y == 0 ? 0 : 1;
            }
            else if (e.Key == Key.Down || e.Key == Key.S)
            {
                tmpY += allyPosition.Y == grdBattleGround.RowDefinitions.Count - 1 ? 0 : 1;
            }
            else if (e.Key == Key.Left || e.Key == Key.A)
            {
                tmpX -= allyPosition.X == 0 ? 0 : 1;
            }
            else if (e.Key == Key.Right || e.Key == Key.D)
            {
                tmpX += allyPosition.X == grdBattleGround.ColumnDefinitions.Count - 1 ? 0 : 1;
            }

            var children = grdBattleGround.Children.Cast<UIElement>().ToList();
            UserControl enemy = null;
            ControlGridTile tile = null;

            foreach(var child in children)
            {
                if(Grid.GetRow(child) == tmpY && Grid.GetColumn(child) == tmpX && child != ally)
                {
                    try
                    {
                        tile = child as ControlGridTile;
                    }
                    catch (InvalidCastException ex)
                    {
                        Console.WriteLine(ex.Message);
                        tile = null;
                    }

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

            //if tile is occupiable, move
            if (tile != null && tile.Occupiable)
            {
                allyPosition.X = tmpX;
                allyPosition.Y = tmpY;

                Grid.SetColumn(ally, (int)allyPosition.X);
                Grid.SetRow(ally, (int)allyPosition.Y);
            }

            if(enemy != null && enemy != ally && enemy != tile)
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
