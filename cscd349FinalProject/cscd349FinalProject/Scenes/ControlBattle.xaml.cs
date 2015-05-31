using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
using Point = System.Windows.Point;
using Pen = System.Windows.Media.Pen;

namespace cscd349FinalProject
{
    /// <summary>
    /// Interaction logic for ControlBattle.xaml
    /// </summary>
    public partial class ControlBattle : UserControl
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

        public ControlBattle()
        {
            InitializeComponent();

            if (Player.GetInstance().Allies.Count == 0)
                throw new Exception("Battle cannot begin, player has no allies!");

            AddPlayerAlliesToScene(Player.GetInstance());

            _computer = Computer.GetInstance();
            _computer.UpdateEnemies();
            AddComputerEnemiesToScene(_computer);

            AddInventoryToScene(InventoryManager.getInstance());

            _battleState = BattleState.PlayerTurn;
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
                Grid.SetColumn(ccbd, 0);
                Grid.SetRow(ccbd, i + 1);
                this.grdControlBattle.Children.Add(ccbd);

            }
        }

        private void AddComputerEnemiesToScene(Computer comp)
        {
            for (int i = 0; i < comp.Enemies.Count; i++)
            {
                var ccbd = new ControlCharacterBattleDisplay(comp.Enemies[i]);
                Grid.SetColumn(ccbd, 2);
                Grid.SetRow(ccbd, i + 1);
                this.grdControlBattle.Children.Add(ccbd);

            }
        }

        private void AddInventoryToScene(InventoryManager im)
        {
            foreach (IInventory inventory in im.AllInventory)
            {
                var ccbd = new ControlIItemCharacterSelectionDisplay(inventory);
                lbInventoryList.Items.Add(ccbd);
            }
        }

        private void DoBattle()
        {
            if (_battleState == BattleState.PlayerTurn)
            {
                PlayerTurn();
                _battleState = BattleState.ComputerTurn;
            }
            else if (_battleState == BattleState.ComputerTurn)
            {
                ComputerTurn();
                _battleState = BattleState.PlayerTurn;
            }
        }

        private void PlayerTurn()
        {
            lblPlayerTurn.Content = "Your turn!";
            lblComputerTurn.Content = String.Empty;
        }

        private void ComputerTurn()
        {
            lblPlayerTurn.Content = String.Empty;
            lblComputerTurn.Content = "Computer's turn!";
        }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            DoBattle();
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
    }
}
