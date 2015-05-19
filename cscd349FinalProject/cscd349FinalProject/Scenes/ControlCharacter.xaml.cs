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
using cscd349FinalProject.Utilities;

namespace cscd349FinalProject
{
    /// <summary>
    /// Interaction logic for ControlCharacter.xaml
    /// </summary>
    public partial class ControlCharacter : UserControl
    {
        private const int finalCheckCount = 3;
        private int curCheckCount;
        private Dictionary<CheckBox, CharacterType> cbDictionary; 

        public ControlCharacter()
        {
            InitializeComponent();
            curCheckCount = 0;
            cbDictionary = CreateCbDictionary();
        }

        private Dictionary<CheckBox, CharacterType> CreateCbDictionary()
        {
            //create a relationship between the checkbox and the
            //character type it represents
            return new Dictionary<CheckBox, CharacterType>
                        {
                            {cbKnightFemale, CharacterType.KnightFemale},
                            {cbKnightMale, CharacterType.KnightMale},
                            {cbMagicianFemale, CharacterType.MagicianFemale},
                            {cbMagicianMale, CharacterType.MagicianMale},
                            {cbNinjaFemale, CharacterType.NinjaFemale},
                            {cbNinjaMale, CharacterType.NinjaMale},
                            {cbSoldierFemale, CharacterType.SoldierFemale},
                            {cbSoldierMale, CharacterType.SoldierMale}
                        };
        }

        private void cb_Checked(object sender, RoutedEventArgs e)
        {
            curCheckCount++;
            EnablePlay();
        }

        private void cb_Unchecked(object sender, RoutedEventArgs e)
        {
            curCheckCount--;
            EnablePlay();
        }

        private void EnablePlay()
        {
            btnPlay.IsEnabled = curCheckCount == finalCheckCount;
        }

        private List<ICharacter> GetSelectedCharacters()
        {
            //find all the checkboxes that were checked
            List<CheckBox> selected = this.grdChooseCharacters.Children.OfType<CheckBox>().Where(x => x.IsChecked == true).ToList();

            List<ICharacter> characters = new List<ICharacter>();

            //map each checkbox to the cbDictionary to find
            //the corresponding character type
            foreach (CheckBox cb in selected)
                //index into the cbDictonary and use the character type to
                //create a character using the factory and add to the list
                characters.Add(CharacterFactory.CreateCharacter(cbDictionary[cb]));

            return characters;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Player.GetInstance().Allies = GetSelectedCharacters();

            MainWindow.GetInstance().ChangeScene(Scene.CharacterSetup);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().ChangeScene(Scene.Main);
        }
    }
}
