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
using cscd349FinalProject.Weapons;

namespace cscd349FinalProject.Scenes
{
    /// <summary>
    /// Interaction logic for ControlCharacterSetup.xaml
    /// </summary>
    public partial class ControlCharacterSetup : UserControl
    {
        public ControlCharacterSetup()
        {
            InitializeComponent();

            btnPlay.IsEnabled = true;   //this should be false, currently set to true for faster testing
            AddPlayerAlliesToScene(Player.GetInstance());
            AddIWeaponsToScene(WeaponManager.GetInstance());
            AddIEquipmentToScene(EquipmentManager.GetInstance());
        }

        private void AddPlayerAlliesToScene(Player play)
        {
            for (int i = 0; i < play.Allies.Count; i++)
            {
                var ccbd = new ControlCharacterBattleDisplay(play.Allies[i]);
                Grid.SetColumn(ccbd, 0);
                Grid.SetRow(ccbd, i + 1);
                this.grdControlCharacterSetup.Children.Add(ccbd);
            }
        }

        private void AddIWeaponsToScene(WeaponManager wm)
        {
            foreach (IWeapon weapon in wm.AllWeapons)
            {
                var cwcsd = new ControlIItemCharacterSelectionDisplay(weapon);
                lbWeaponList.Items.Add(cwcsd);
            }
        }

        private void AddIEquipmentToScene(EquipmentManager em)
        {
            foreach (IEquipment equipment in em.AllEquipments)
            {
                var cicsd = new ControlIItemCharacterSelectionDisplay(equipment);
                lbEquipmentList.Items.Add(cicsd);
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().ChangeScene(Scene.GamePlay);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().ChangeScene(Scene.Character);
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
                        {
                            source.Items.Remove(source.SelectedItem);

                            List<IItem> missing = findMissingItems(source);

                            //add the missing items back to the list
                            foreach (IItem m in missing)
                            {
                                source.Items.Insert(0, new ControlIItemCharacterSelectionDisplay(m));
                            }

                            checkReadyToPlay();
                        }
                    }
                }
            }
        }

        private List<IItem> findMissingItems(ListBox source)
        {
            //figure out if the source is holding weapon or armor
            if (source == lbWeaponList)
            {
                //get all the items that the player has selected
                List<IItem> playerItems = new List<IItem>();
                foreach (ICharacter c in Player.GetInstance().Allies)
                {
                    playerItems.Add(c.Weapon);
                    //playerItems.Add(c.Equipment);
                }

                //get all the items left in the list box
                List<IItem> remaining = new List<IItem>();
                foreach (var u in source.Items)
                {
                    ControlIItemCharacterSelectionDisplay c =
                        (u as UserControl) as ControlIItemCharacterSelectionDisplay;
                    if (c != null)
                        remaining.Add(c.Item);
                }

                //get all the items that were in the list box to begin with
                List<IItem> allItems = new List<IItem>();
                foreach (IWeapon w in WeaponManager.GetInstance().AllWeapons)
                    allItems.Add(w);

                //find which items are missing from both the player and the list box
                List<IItem> missing = allItems.Except(remaining.Union(playerItems)).ToList();

                return missing;
            }

            if (source == lbEquipmentList)
            {
                //get all the items that the player has selected
                List<IItem> playerItems = new List<IItem>();
                foreach (ICharacter c in Player.GetInstance().Allies)
                {
                    playerItems.Add(c.Equipment);
                }

                //get all the items left in the list box
                List<IItem> remaining = new List<IItem>();
                foreach (var u in source.Items)
                {
                    ControlIItemCharacterSelectionDisplay c =
                        (u as UserControl) as ControlIItemCharacterSelectionDisplay;
                    if (c != null)
                        remaining.Add(c.Item);
                }

                //get all the items that were in the list box to begin with
                List<IItem> allItems = new List<IItem>();
                foreach (IEquipment e in EquipmentManager.GetInstance().AllEquipments)
                    allItems.Add(e);

                //find which items are missing from both the player and the list box
                List<IItem> missing = allItems.Except(remaining.Union(playerItems)).ToList();

                return missing;
            }

            return null;

        }

        private void checkReadyToPlay()
        {
            bool ready = true;
            foreach (ICharacter c in Player.GetInstance().Allies)
            {
                if (c.Weapon.HitPoints.Value == 0)  //this is a WeaponNull
                    ready = false;
                if (c.Equipment.HitPoints.Value == 0)   //this is a EquipmentNull
                    ready = false;
            }

            btnPlay.IsEnabled = ready;
        }
    }
}
