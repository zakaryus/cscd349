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
    /// Interaction logic for ControlIItemCharacterSelectionDisplay.xaml
    /// </summary>
    public partial class ControlIItemCharacterSelectionDisplay : UserControl
    {
        private IItem _item;

        public IItem Item
        {
            get { return _item; }
            private set { _item = value; }
        }

        public ControlIItemCharacterSelectionDisplay(IItem item)
        {
            InitializeComponent();
            Item = item;

            lblName.Content = Item.Name;
            lblHitPoints.Content = Item.HitPoints.Value.ToString();
            tblkDescription.Text = Item.Description;
            weaponIcon.Source = Item.Icon.Source;
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
