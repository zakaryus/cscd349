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
                        DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
                    }
                }
            }
        }


    }
}
