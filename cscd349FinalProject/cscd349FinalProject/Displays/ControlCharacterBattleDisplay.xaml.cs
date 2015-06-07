﻿using System;
using System.Collections.Generic;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using cscd349FinalProject.Interfaces;
using cscd349FinalProject.Utilities;

namespace cscd349FinalProject
{
    /// <summary>
    /// Interaction logic for ControlCharacterBattleDisplay.xaml
    /// </summary>
    public partial class ControlCharacterBattleDisplay : UserControl, IWatcher, IWatchee
    {
        private ICharacter _character;
        private HitPoint _tmpMaxHitPoints;
        private Timer _tmrLblDamage, _tmrBdrAttacker, _tmrBdrVictim;
        private List<IWatcher> _watchers; 
        
        public bool Draggable { get; set; }

        public ICharacter Character
        {
            get { return _character; }
            private set { _character = value; }
        }

        public ControlCharacterBattleDisplay(ICharacter ichar)
        {
            InitializeComponent();

            Character = ichar;
            Character.Register(this);
            imgFace.Source = Character.Face.Source;

            lblName.Content = Character.Name;
            imgWeapon.Source = Character.Weapon.Icon.Source;
            imgEquipment.Source = Character.Equipment.Icon.Source;
            lblDamageTaken.Content = String.Empty;

            _tmpMaxHitPoints = Character.MaxHitPoints;
            pbHitPoints.Maximum = Character.MaxHitPoints.Value;
            pbHitPoints.Minimum = 0;
            SetPbHitPoints();

            ToolTip tt = new ToolTip();
            tt.Content = String.Format("Damage: {0}", Character.Weapon.HitPoints.Value.ToString());
            imgWeapon.ToolTip = tt;

            ToolTip tt2 = new ToolTip();
            tt2.Content = String.Format("Protects: {0}", Character.Equipment.HitPoints.Value.ToString());
            imgEquipment.ToolTip = tt2;

            ToolTip tt3 = new ToolTip();
            tt3.Content = Character.Description;
            imgFace.ToolTip = tt3;

            Watchers = new List<IWatcher>();
            Draggable = true;
            this.IsEnabled = true;
        }

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            imgFace.Source = Character.Face.Source;

            lblName.Content = Character.Name;
            imgWeapon.Source = Character.Weapon.Icon.Source;
            imgEquipment.Source = Character.Equipment.Icon.Source;

            pbHitPoints.Maximum = Character.MaxHitPoints.Value;
            pbHitPoints.Minimum = 0;
            SetPbHitPoints();
        }

        public void SetPbHitPoints()
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(1.5));
            DoubleAnimation doubleanimation = new DoubleAnimation(Character.HitPoints.Value, duration);
            pbHitPoints.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
            lblHitPointFraction.Content = GetFormattedHitPointFraction();
        }

        private string GetFormattedHitPointFraction()
        {
            return String.Format("{0} / {1}", Character.HitPoints.Value, Character.MaxHitPoints.Value);
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Console.WriteLine(Draggable);
                if (!Draggable)
                    return;

                var source = sender as UserControl;

                if (source != null)
                {
                    var display = source as ControlCharacterBattleDisplay;

                    if (display != null)
                    {
                        var character = display.Character;

                        //if (Computer.GetInstance().Enemies.Contains(character))
                        //    return;

                        var data = new DataObject(typeof(UserControl), source);

                        // Inititate the drag-and-drop operation.
                        var result = DragDrop.DoDragDrop(this, data, DragDropEffects.Move);

                        // If successfull attack, notify watchers
                        if (result == DragDropEffects.Move)
                            Notify();
                    }
                }
            }
        }

        public void UserControl_Drop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);

            e.Effects = DragDropEffects.None;

            if (e.Handled == false)
            {
                var display = sender as ControlCharacterBattleDisplay;
                var data = e.Data as DataObject;

                if (display != null)
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

                        Character.MaxHitPoints = _tmpMaxHitPoints + Character.Equipment.HitPoints;
                        Character.HitPoints = _tmpMaxHitPoints + Character.Equipment.HitPoints;

                        display.InvalidateVisual();
                    }
                    else if (TryDataToInventory(control))
                    {
                        Character.HitPoints += DataToInventory(control).UseInventory();
                        display.InvalidateVisual();
                    }
                    else if (TryDataToCharacter(control))
                    {
                        Battle(control as ControlCharacterBattleDisplay, e);
                    }
                }
            }
        }

        public void Battle(ControlCharacterBattleDisplay attackerDisp, DragEventArgs e = null)
        {
            //battle is happening
            var attacker = DataToCharacter(attackerDisp);
            var victim = this.Character;

            //no suicide
            if (attacker == victim)
            {
                if(e != null)
                    e.Effects = DragDropEffects.None;
                return;
            }

            //no backstabbing
            if (Player.GetInstance().Allies.Contains(attacker) &&
                Player.GetInstance().Allies.Contains(victim))
            {
                if(e != null)
                    e.Effects = DragDropEffects.None;
                return;
            }

            SetBorder(attackerDisp, true);
            SetBorder(this, false);

            _tmrBdrAttacker = new Timer(ClearBorder, attackerDisp, 2020, 0);
            _tmrBdrVictim = new Timer(ClearBorder, this, 2010, 0);

            HitPoint hit = attacker.Attack();
            victim.HitPoints -= hit;

            //if the hitpoints are 0 we will display "KO'd"
            if (victim.HitPoints.Value != 0)
            {
                lblDamageTaken.Content = String.Format("- {0}", hit.Value.ToString());
                _tmrLblDamage = new Timer(ClearLabel, lblDamageTaken, 2000, 0);
            }

            this.InvalidateVisual();

            if (e != null)
                e.Effects = DragDropEffects.Move;
        }

        private void ClearLabel(Object o)
        {
            var lbl = o as Label;
            if (lbl != null)
                Dispatcher.BeginInvoke((Action)(() => { lbl.Content = String.Empty; }));
        }

        private void ClearBorder(Object o)
        {
            var disp = o as ControlCharacterBattleDisplay;
            if(disp != null)
                Dispatcher.BeginInvoke((Action)(() => { disp.BorderBrush = Brushes.Transparent; }));
        }

        private void SetBorder(Object o, bool isAttacker)
        {
            var disp = o as ControlCharacterBattleDisplay;
            if (disp != null)
            {
                if (isAttacker)
                    disp.BorderBrush = Brushes.Green;
                else
                    disp.BorderBrush = Brushes.Red;

                disp.BorderThickness = new Thickness(3);
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
                return DataToEquipment(control) != null;
            }
            catch (InvalidCastException e)
            {
                return false;
            }
        }
        
        private bool TryDataToInventory(UserControl control)
        {
            try
            {
                return DataToInventory(control) != null;
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

        private IInventory DataToInventory(UserControl control)
        {
            var display = control as ControlIItemCharacterSelectionDisplay;

            if (display != null)
            {
                var inventory = display.Item as IInventory;
                return inventory;
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

        public void BeNotified(IWatchee i)
        {
            var ally = i as ICharacter;
            if (ally != null)
            {
                //if a battledisplay is notified by a character, 
                //and it is the same as the character contained
                //in the display, the character has died
                if (ally == _character)
                {
                    lblDamageTaken.Content = "KO'd";
                    IsEnabled = false;
                    InvalidateVisual();
                }
            }
        }

        public List<IWatcher> Watchers
        {
            get { return _watchers; }
            private set { _watchers = value; }
        }

        public void Register(IWatcher i)
        {
            if (Watchers == null)
                throw new NullReferenceException();

            if (!Watchers.Contains(i))
                _watchers.Add(i);
        }

        public void Unregister(IWatcher i)
        {
            if (Watchers == null)
                throw new NullReferenceException();

            if (_watchers.Contains(i))
                _watchers.Remove(i);
        }

        public void Notify()
        {
            if (Watchers == null)
                throw new NullReferenceException();

            foreach (IWatcher i in Watchers)
                i.BeNotified(this);
        }
    }
}
