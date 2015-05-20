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

        public ControlCharacterBattleDisplay(ICharacter ichar)
        {
            InitializeComponent();

            _highlighted = false;
            _highlightedColor = new SolidColorBrush(Color.FromArgb(128, 0, 0, 255));
            _unhighlightedColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));

            _character = ichar;
            imgFace.Source = _character.Face.Source;

            lblName.Content = _character.Name;
            lblDamageTaken.Content = String.Empty;

            pbHitPoints.Maximum = _character.MaxHitPoints.Value;
            pbHitPoints.Minimum = 0;
            SetPbHitPoints(_character.HitPoints);
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

            _character.Weapon = e.Data.GetData("Object") as IWeapon;
            lblWeaponName.Content = _character.Weapon.Name;
            e.Effects = DragDropEffects.Move;
            e.Handled = true;
        }
    }
}
