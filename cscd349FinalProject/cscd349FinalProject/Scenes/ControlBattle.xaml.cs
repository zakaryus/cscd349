using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
using cscd349FinalProject.Interfaces;
using Point = System.Windows.Point;
using Pen = System.Windows.Media.Pen;
using System.Windows.Threading;

namespace cscd349FinalProject
{
    /// <summary>
    /// Interaction logic for ControlBattle.xaml
    /// </summary>
    /// 
    public partial class ControlBattle : UserControl, IWatcher
    {
        private enum BattleState
        {
            PlayerTurn,
            ComputerTurn,
            Won,
            Lost
        }

        private BattleState _battleState;
        private Computer _computer;
        private int _turnCounter;
        private List<ControlCharacterBattleDisplay> _allyDisplays;
        private List<ControlCharacterBattleDisplay> _enemyDisplays; 

        public ControlBattle()
        {
            InitializeComponent();

            if (Player.GetInstance().Allies.Count == 0)
                throw new Exception("Battle cannot begin, player has no allies!");

            _allyDisplays = new List<ControlCharacterBattleDisplay>();
            AddPlayerAlliesToScene(Player.GetInstance());

            _computer = Computer.GetInstance();
            _computer.UpdateEnemies();
            _enemyDisplays = new List<ControlCharacterBattleDisplay>();
            AddComputerEnemiesToScene(_computer);

            AddInventoryToScene(Player.GetInstance());

            _battleState = BattleState.PlayerTurn;
            PlayerTurn();
            _turnCounter = 0;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow.GetInstance().ChangeScene(Scene.GamePlay);
        }

        private void btnLose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().ChangeScene(Scene.Lose);
        }

        private void AddPlayerAlliesToScene(Player play)
        {
            for (int i = 0; i < play.Allies.Count; i++)
            {
                var ccbd = new ControlCharacterBattleDisplay(play.Allies[i]);
                ccbd.IsEnabled = !play.Allies[i].Dead;
                ccbd.Register(this);
                Grid.SetColumn(ccbd, 0);
                Grid.SetRow(ccbd, i + 1);
                this.grdControlBattle.Children.Add(ccbd);
                _allyDisplays.Add(ccbd);
            }
        }

        private void AddComputerEnemiesToScene(Computer comp)
        {
            for (int i = 0; i < comp.Enemies.Count; i++)
            {
                var ccbd = new ControlCharacterBattleDisplay(comp.Enemies[i]);
                ccbd.Register(this);
                Grid.SetColumn(ccbd, 2);
                Grid.SetRow(ccbd, i + 1);
                this.grdControlBattle.Children.Add(ccbd);
                _enemyDisplays.Add(ccbd);
            }
        }

        private void AddInventoryToScene(Player play)
        {
            for (int i = 0; i < play.Inventory.Count; i++)
            {
                var ccbd = new ControlIItemCharacterSelectionDisplay(play.Inventory[i]);
                lbInventoryList.Items.Add(ccbd);
            }
        }

        private void PlayerTurn()
        {
            lblPlayerTurn.Content = "Your turn!";
            lblComputerTurn.Content = String.Empty;

            foreach (var disp in _allyDisplays)
                disp.Draggable = true;

            foreach (var disp in _enemyDisplays)
                disp.Draggable = false;

            lbInventoryList.IsEnabled = true;
        }

        private void ComputerTurn()
        {
            lblPlayerTurn.Content = String.Empty;
            lblComputerTurn.Content = "Computer's turn!";

            foreach (var disp in _allyDisplays)
                disp.Draggable = false;

            foreach (var disp in _enemyDisplays)
                disp.Draggable = true;

            lbInventoryList.IsEnabled = false;
        }

        private void lbItemList_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var source = sender as ListBox;

                if (source != null)
                {
                    var sourceControl = source.SelectedItem as UserControl;

                    if (sourceControl != null)
                    {

                        var data = new DataObject(typeof (UserControl), sourceControl);

                        // Inititate the drag-and-drop operation.
                        DragDropEffects res = DragDrop.DoDragDrop(this, data, DragDropEffects.Move);

                        //if the drag was successful
                        if (res == DragDropEffects.Move)
                            source.Items.Remove(source.SelectedItem);
                    }
                }
            }
        }

        //Battle Logic
        //1. Player starts, all player allies attack, after each attack check for win
        //2. Computer starts, all computer enemies attack, after each attack check for loss
        public void BeNotified(IWatchee i)
        {
            var disp = i as ControlCharacterBattleDisplay;
            if (disp != null)
            {
                BattleState previousBattleState = _battleState;
                disp.Draggable = false;

                if (Player.GetInstance().Allies.Contains(disp.Character))
                {
                    int enemiesDead = Computer.GetInstance().Enemies.Where(c => c.Dead).ToList().Count;
                    int enemiesAll = Computer.GetInstance().Enemies.Count;

                    if (enemiesDead == enemiesAll)
                    {
                        _battleState = BattleState.Won;
                    }
                    else
                    {
                        var alive = Player.GetInstance().Allies.Where(c => !c.Dead).ToList();
                        if (_turnCounter == alive.Count - 1)
                        {
                            _battleState = BattleState.ComputerTurn;
                            _turnCounter = 0;
                        }
                        else
                            _turnCounter++;
                    }
                }
                else if (Computer.GetInstance().Enemies.Contains(disp.Character))
                {
                    int alliesDead = Player.GetInstance().Allies.Where(c => c.Dead).ToList().Count;
                    int alliesAll = Player.GetInstance().Allies.Count;

                    if (alliesDead == alliesAll)
                    {
                        _battleState = BattleState.Lost;
                    }
                    else
                    {
                        var alive = Computer.GetInstance().Enemies.Where(c => !c.Dead).ToList();
                        if (_turnCounter == alive.Count - 1)
                        {
                            _battleState = BattleState.PlayerTurn;
                            _turnCounter = 0;
                        }
                        else
                            _turnCounter++;
                    }
                }

                HandleBattleState(previousBattleState);
            }
        }

        private void HandleBattleState(BattleState prior)
        {
            if (_battleState == BattleState.PlayerTurn && prior != BattleState.PlayerTurn)
            {
                PlayerTurn();
            }
            else if (_battleState == BattleState.ComputerTurn && prior != BattleState.ComputerTurn)
            {
                ComputerTurn();

                foreach (var disp in _allyDisplays)
                    disp.Draggable = false;

                Random rand = new Random();
                int delay = 0;
                foreach (var disp in _enemyDisplays)
                {
                    if (!disp.IsEnabled)
                        continue;

                    disp.Draggable = true;

                    var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2.2 + (2.2 * delay++)) };
                    timer.Start();
                    timer.Tick += (sender, args) =>
                    {
                        timer.Stop();
                        var victims = _allyDisplays.Where(d => !d.Character.Dead).ToList();

                        if (victims.Count > 0)
                        {
                            var victim = victims[rand.Next() % victims.Count];
                            victim.Battle(disp);
                            disp.Notify();
                        }
                    };
                }
            }
            else if (_battleState == BattleState.Lost)
            {
                var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
                timer.Start();
                timer.Tick += (sender, args) =>
                {
                    timer.Stop();
                    MainWindow.GetInstance().ChangeScene(Scene.Lose);
                };
            }
            else if (_battleState == BattleState.Won)
            {
                var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
                timer.Start();
                timer.Tick += (sender, args) =>
                {
                    timer.Stop();
                    MainWindow.GetInstance().ChangeScene(Scene.GamePlay);
                };   
            }
        }
    }
}
