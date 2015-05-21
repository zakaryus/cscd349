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
    /// Interaction logic for ControlCharacterBattleDisplay.xaml
    /// </summary>
    public partial class ControlCharacterBattleDisplay : UserControl
    {
        private ICharacter _character;
        private bool _highlighted;
        Brush _highlightedColor, _unhighlightedColor;

        public bool Highlighted
        {
            get { return _highlighted; }
            private set { _highlighted = value; }
        }

        public ICharacter Character
        {
            get { return _character; }
            private set { _character = value; }
        }

        public ControlCharacterBattleDisplay(ICharacter ichar)
        {
            InitializeComponent();

            _highlighted = false;
            _highlightedColor = new SolidColorBrush(Color.FromArgb(128, 0, 0, 255));
            _unhighlightedColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));

            Character = ichar;
            imgFace.Source = Character.Face.Source;

            lblName.Content = Character.Name;
            imgWeapon.Source = Character.Weapon.Icon.Source;
            imgEquipment.Source = Character.Weapon.Icon.Source;
            lblDamageTaken.Content = String.Empty;

            pbHitPoints.Maximum = Character.MaxHitPoints.Value;
            pbHitPoints.Minimum = 0;
            SetPbHitPoints(Character.HitPoints);
        }



        public void SetPbHitPoints(HitPoint hitpoints)
        {
            pbHitPoints.Value = hitpoints.Value;
            lblHitPointFraction.Content = GetFormattedHitPointFraction();
        }

        private string GetFormattedHitPointFraction()
        {
            return String.Format("{0} / {1}", pbHitPoints.Value, pbHitPoints.Maximum);
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grdBattleDisplay.Background = Highlighted ? _unhighlightedColor : _highlightedColor;
            Highlighted = !Highlighted;
        }

        private void UserControl_Drop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);

            if (e.Handled == false)
            {
                var character = sender as ControlCharacterBattleDisplay;
                var data = e.Data as DataObject;

                if (character != null)
                {
                    var control = data.GetData(typeof(UserControl)) as UserControl;

                    if (TryDataToWeapon(control))
                    {
                        Character.Weapon = DataToWeapon(control);
                        imgWeapon.Source = Character.Weapon.Icon.Source;
                    }
                    else if (TryDataToEquipment(control))
                    {
                        Character.Equipment = DataToEquipment(control);
                        imgEquipment.Source = Character.Equipment.Icon.Source;
                    }
                    else if (TryDataToCharacter(control))
                    {
                        //battle is happening
                    }
                }
            }
        }

        private bool TryDataToWeapon(UserControl control)
        {
            try
            {
                return DataToWeapon(control) != null;
            }
            catch (InvalidCastException e)
            {
                return false;
            }
        }

        private IWeapon DataToWeapon(UserControl control)
        {
            var display = control as ControlIItemCharacterSelectionDisplay;

            if (display != null)
            {
                var weapon = display.Item as IWeapon;
                return weapon;
            }

            return null;
        }

        private bool TryDataToEquipment(UserControl control)
        {
            try
            {
                return DataToWeapon(control) != null;
            }
            catch (InvalidCastException e)
            {
                return false;
            }
        }

        private IEquipment DataToEquipment(UserControl control)
        {
            var display = control as ControlIItemCharacterSelectionDisplay;

            if (display != null)
            {
                var equipment = display.Item as IEquipment;
                return equipment;
            }

            return null;
        }

        private bool TryDataToCharacter(UserControl control)
        {
            try
            {
                return DataToCharacter(control) != null;
            }
            catch (InvalidCastException e)
            {
                return false;
            }
        }

        private ICharacter DataToCharacter(UserControl control)
        {
            var display = control as ControlCharacterBattleDisplay;

            if (display != null)
            {
                var character = display.Character as ICharacter;
                return character;
            }

            return null;
        }
    }
}
