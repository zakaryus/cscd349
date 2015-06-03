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
using cscd349FinalProject.Interfaces;

namespace cscd349FinalProject
{
    /// <summary>
    /// Interaction logic for ControlGamePlay.xaml
    /// </summary>
    public partial class ControlGamePlay : UserControl
    {
        private UserControl _ally;
        private Point _allyPosition;

        public ControlGamePlay()
        {
            InitializeComponent();

            MazeCreator mc = new MazeCreator(15, 33);
            Byte[,] maze = mc.CreateMaze();

            Random r = new Random();
            int enemyNum = 0;
            for (int i = 0; i < grdBattleGround.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < grdBattleGround.ColumnDefinitions.Count; j++)
                {           
                    int n = r.Next();
                    if (i == 15)
                        continue;

                    TileType type = maze[i, j] == 0 ? TileType.Floor : TileType.Wall;

                    ControlGridTile gt = new ControlGridTile(type);
                    addControlToGridAtPoint(gt, i, j);

                    if (n % 23 == 0 && type == TileType.Floor)
                    {
                        //TODO: Create a user control representing an enemy on the board
                        UserControl uc = new UserControl();
                        uc.Content = enemyNum++.ToString();
                        addControlToGridAtPoint(uc, i, j);
                    }
                }
            }

            //TODO: Create a user control representing an ally on the board
            
    
            _allyPosition = new Point(1, 1);
            _ally = new UserControl();
           Image rep = new Image();
           rep.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/KnightMale/KnightFront.png");
           _ally.Content = rep;

            var l = Player.GetInstance().Allies;

            addControlToGridAtPoint(_ally, (int)_allyPosition.X, (int)_allyPosition.Y);

            //TODO: Create a user control representing the exit on the board
            UserControl exit = new UserControl();
            exit.Content = "EX\nIT";
            addControlToGridAtPoint(exit, grdBattleGround.RowDefinitions.Count - 2, grdBattleGround.ColumnDefinitions.Count - 2);
        }

        private void addControlToGridAtPoint(UserControl uc, int x, int y)
        {
            Grid.SetColumn(uc, y);
            Grid.SetRow(uc, x);
            grdBattleGround.Children.Add(uc);
        }

        private void grdBattleGround_KeyDown(object sender, KeyEventArgs e)
        {
            ICharacter leader = new CharacterSoldierMale();
            int num = Player.GetInstance().Allies.Count;
            //if (num > 0)
            //{
            //    MessageBox.Show("num is" + num);
            //    leader = Player.GetInstance().Allies[0];
            //    MessageBox.Show(leader.Name);
            //}
            int tmpX = (int)_allyPosition.X;
            int tmpY = (int)_allyPosition.Y;

            if (/*e.Key == Key.Up ||*/ e.Key == Key.W)
            {
                tmpY -= (int)_allyPosition.Y == 0 ? 0 : 1;
                _ally.Content = leader.Back;
            }
            else if (/*e.Key == Key.Down ||*/ e.Key == Key.S)
            {
                tmpY += (int)_allyPosition.Y == grdBattleGround.RowDefinitions.Count - 1 ? 0 : 1;
                _ally.Content = leader.Front;
            }
            else if (/*e.Key == Key.Left ||*/ e.Key == Key.A)
            {
                tmpX -= (int)_allyPosition.X == 0 ? 0 : 1;
                _ally.Content = leader.Left;
            }
            else if (/*e.Key == Key.Right ||*/ e.Key == Key.D)
            {
                tmpX += (int)_allyPosition.X == grdBattleGround.ColumnDefinitions.Count - 1 ? 0 : 1;
                _ally.Content = leader.Right;
            }

            var children = grdBattleGround.Children.Cast<UIElement>().ToList();
            UserControl enemy = null;
            ControlGridTile tile = null;

            foreach(var child in children)
            {
                if(Grid.GetRow(child) == tmpY && Grid.GetColumn(child) == tmpX && child != _ally)
                {
                    try
                    {
                        //find the tile we attempting to move to
                        tile = child as ControlGridTile;
                    }
                    catch (InvalidCastException ex)
                    {
                        Console.WriteLine(ex.Message);
                        tile = null;
                    }

                    try
                    {
                        //find the enemy where we are attempting to move, if there is one
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
                _allyPosition.X = tmpX;
                _allyPosition.Y = tmpY;

                Grid.SetColumn(_ally, (int)_allyPosition.X);
                Grid.SetRow(_ally, (int)_allyPosition.Y);
            }

            if(enemy != null && enemy != _ally && enemy != tile)
            {
                var res = MessageBox.Show("Enemy " + enemy.Content + " encountered!", "Battle", MessageBoxButton.OK);
                if (res == MessageBoxResult.OK)
                {
                    grdBattleGround.Children.Remove(enemy);
                    MainWindow.GetInstance().ChangeScene(Scene.Battle);
                }
            }

            grdBattleGround.Focus();
        }

        private void grdBattleGround_Loaded(object sender, RoutedEventArgs e)
        {
            if (!grdBattleGround.IsFocused)
                grdBattleGround.Focus();
        }
    }
}
