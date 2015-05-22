using System;
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
using cscd349FinalProject.Utilities;

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
            imgEquipment.Source = Character.Equipment.Icon.Source;
            lblDamageTaken.Content = String.Empty;

            pbHitPoints.Maximum = Character.MaxHitPoints.Value;
            pbHitPoints.Minimum = 0;
            SetPbHitPoints();

            ToolTip tt = new ToolTip();
            tt.Content = String.Format("Damage: {0}", Character.Weapon.HitPoints.Value.ToString());
            imgWeapon.ToolTip = tt;

            ToolTip tt2 = new ToolTip();
            tt2.Content = String.Format("Protects: {0}", Character.Equipment.HitPoints.Value.ToString());
            imgEquipment.ToolTip = tt2;
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

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grdBattleDisplay.Background = Highlighted ? _unhighlightedColor : _highlightedColor;
            Highlighted = !Highlighted;
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var source = sender as UserControl;

                if (source != null)
                {
                    var data = new DataObject(typeof(UserControl), source);

                    // Inititate the drag-and-drop operation.
                    DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
                }
            }
        }

        private void UserControl_Drop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);

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
                        Character.HitPoints += Character.Equipment.HitPoints;
                        Character.MaxHitPoints += Character.Equipment.HitPoints;
                        display.InvalidateVisual();

                    }
                    else if (TryDataToCharacter(control))
                    {
                        //battle is happening
                        var attacker = DataToCharacter(control);
                        var victim = display.Character;

                        HitPoint hit = attacker.Attack();
                        victim.HitPoints -= hit;

                        Timer t = new Timer(ClearLabel, lblDamageTaken, 2000, 0);
                        lblDamageTaken.Content = String.Format("- {0}", hit.Value.ToString());
                        
                        display.InvalidateVisual();
                    }
                }
            }
        }

        private void ClearLabel(Object o)
        {
            var lbl = o as Label;
            if (lbl != null)
            {
                if (!Dispatcher.CheckAccess())
                    Dispatcher.Invoke(() => lbl.Content = String.Empty, DispatcherPriority.Normal);
                else
                    lbl.Content = String.Empty;
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
