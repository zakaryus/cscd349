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
using cscd349FinalProject.Items;
using cscd349FinalProject.Utilities;

namespace cscd349FinalProject
{
    /// <summary>
    /// Interaction logic for ControlGamePlay.xaml
    /// </summary>
    public partial class ControlGamePlay : UserControl
    {
        private ControlCharacterMapDisplay _ally;
        private Point _allyPosition;
        private ICharacter _leader;

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
                    TileType type = maze[i, j] == 0 ? TileType.Floor : TileType.Wall;

                    ControlGridTile gt = new ControlGridTile(type);
                    addControlToGridAtPoint(gt, i, j);
                    if (i == 1 && j == 1)
                        continue;

                   

                    if (n % 23 == 0 && type == TileType.Floor)
                    {
                        var uc = new ControlCharacterMapDisplay(Factory.CreateRandomEnemy());
                        addControlToGridAtPoint(uc, i, j);
                        continue;
                    }

                    if (n % 19 == 0 && type == TileType.Floor)
                    {
                        var uc = new ControlItemMapDisplay(Factory.CreateRandomInventory());
                        addControlToGridAtPoint(uc, i, j);
                    }
                }
            }            
    
           _allyPosition = new Point(1, 1);
           _ally = new ControlCharacterMapDisplay(GetLeader());
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

        private ICharacter GetLeader()
        {  
            if (Player.GetInstance().Allies.Count > 0)
            {
                foreach (ICharacter c in Player.GetInstance().Allies)
                {
                    if (c.HitPoints.Value > 0)
                    {
                        _leader = c;
                        return _leader;
                    }
                }
            }

            MainWindow.GetInstance().ChangeScene(Scene.Lose);
 
            return null;

        }
        
        private void grdBattleGround_KeyDown(object sender, KeyEventArgs e)
        {
            int tmpX = (int)_allyPosition.X;
            int tmpY = (int)_allyPosition.Y;

            if (/*e.Key == Key.Up ||*/ e.Key == Key.W)
            {
                tmpY -= (int)_allyPosition.Y == 0 ? 0 : 1;
                _ally.MoveUp();

            }
            else if (/*e.Key == Key.Down ||*/ e.Key == Key.S)
            {
                tmpY += (int)_allyPosition.Y == grdBattleGround.RowDefinitions.Count - 1 ? 0 : 1;
                _ally.MoveDown();
            }
            else if (/*e.Key == Key.Left ||*/ e.Key == Key.A)
            {
                tmpX -= (int)_allyPosition.X == 0 ? 0 : 1;
                _ally.MoveLeft();
            }
            else if (/*e.Key == Key.Right ||*/ e.Key == Key.D)
            {
                tmpX += (int)_allyPosition.X == grdBattleGround.ColumnDefinitions.Count - 1 ? 0 : 1;
                _ally.MoveRight();
            }

            var children = grdBattleGround.Children.Cast<UIElement>().ToList();
            ControlCharacterMapDisplay enemy = null;
            ControlGridTile tile = null;
            ControlItemMapDisplay item = null;
            foreach(var child in children)
            {
                if(Grid.GetRow(child) == tmpY && Grid.GetColumn(child) == tmpX && child != _ally)
                {
                    try
                    {
                        //find the tile we attempting to move to
                        if(tile == null)
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
                        if(enemy == null)
                            enemy = child as ControlCharacterMapDisplay;
                    }
                    catch(InvalidCastException ex)
                    {
                        Console.WriteLine(ex.Message);
                        enemy = null;
                    }

                    try
                    {
                        //find the enemy where we are attempting to move, if there is one
                        if(item == null)
                            item = child as ControlItemMapDisplay;
                    }
                    catch (InvalidCastException ex)
                    {
                        Console.WriteLine(ex.Message);
                       item = null;
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

            if (item != null)
            {
                Player.GetInstance().Inventory.Add(item.Item);
                grdBattleGround.Children.Remove(item);
            }

            if(enemy != null && enemy != _ally )
            {
                var res = MessageBox.Show("Enemy Encountered!", "Battle", MessageBoxButton.OK);
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_leader.HitPoints.Value < 0)
            {
                _ally.Character = GetLeader();
                InvalidateVisual();
            }   
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            _ally.Character = GetLeader();
            _ally.MoveDown();
        }
    }
}
