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
using cscd349FinalProject.Interfaces;

namespace cscd349FinalProject.Displays
{
    /// <summary>
    /// Interaction logic for ControlCharacterMapDisplay.xaml
    /// </summary>
    public partial class ControlCharacterMapDisplay : UserControl
    {
        private ICharacter character;

        public ICharacter Character
        {
            get { return character; }
            set { character = value; }
        }

        public ControlCharacterMapDisplay(ICharacter c)
        {
            InitializeComponent();
            imgCharacterDisplay.Source = c.Front.Source;
            character = c;
        }

        public void MoveLeft()
        {
            imgCharacterDisplay.Source = character.Left.Source;
        }
        public void MoveRight()
        {
            imgCharacterDisplay.Source = character.Right.Source;
        }
        public void MoveDown()
        {
            imgCharacterDisplay.Source = character.Front.Source;
        }
        public void MoveUp()
        {
            imgCharacterDisplay.Source = character.Back.Source;
        }


    }
}
