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
    /// Interaction logic for ControlIWeaponCharacterSelectionDisplay.xaml
    /// </summary>
    public partial class ControlIWeaponCharacterSelectionDisplay : UserControl
    {
        private IWeapon _weapon;

        public IWeapon Weapon
        {
            get { return _weapon; }
            private set { _weapon = value; }
        }

        public ControlIWeaponCharacterSelectionDisplay(IWeapon weapon)
        {
            InitializeComponent();
            Weapon = weapon;

            lblName.Content = Weapon.Name;
            lblHitPoints.Content = Weapon.HitPoints.Value.ToString();
            tblkDescription.Text = Weapon.Description;
        }

        private void UserControl_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's 
            // DragOver event handler. 
            if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Pen);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }
    }
}
