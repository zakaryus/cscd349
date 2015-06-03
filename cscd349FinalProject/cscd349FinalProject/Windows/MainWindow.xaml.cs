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
using cscd349FinalProject.Scenes;

namespace cscd349FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public enum Scene
    {
        Main, Character, CharacterSetup, GamePlay, Battle, Win, Lose
    }

    public partial class MainWindow : Window
    {
        private static MainWindow _instance = null;
        private static Dictionary<Scene, Control> _scenes = null;
        private static bool _newGame;

        //Singleton
        public static MainWindow GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MainWindow();
                _scenes = _instance.CreateScenes();
                _instance.ChangeScene(Scene.Main);
                _newGame = true;
            }

            return _instance;
        }

        private MainWindow()
        {
            InitializeComponent();
        }

        private Dictionary<Scene, Control> CreateScenes()
        {
            Control main = new ControlMain();
            Control character = new ControlCharacter();
            //Control characterSetup = new ControlCharacterSetup();
            //Control gameplay = new ControlGamePlay();
            //Control battle = new ControlBattle();
            Control win = new ControlWin();
            Control lose = new ControlLose();

            return new Dictionary<Scene, Control>
                   {
                       {Scene.Main, main},
                       {Scene.Character, character},
                       {Scene.CharacterSetup, null},    //null for a new character setup on every scene change
                       {Scene.GamePlay, null},      //null so that a new map is created on each gameplay
                       {Scene.Battle, null},    //null for a new battle on every scene change
                       {Scene.Win, win},
                       {Scene.Lose, lose}
                   };
        }

        public void ChangeScene(Scene scene)
        {
            if (_scenes == null)
                return;

            if (_scenes.ContainsKey(scene))
            {
                //reset the maze after win/lose
                if (scene == Scene.Win || scene == Scene.Lose)
                    _newGame = true;

                if (scene == Scene.CharacterSetup)
                    _instance.cctrlMain.Content = new ControlCharacterSetup();
                else if (scene == Scene.Battle)
                    _instance.cctrlMain.Content = new ControlBattle();
                else if (scene == Scene.GamePlay && _newGame)
                {
                    _scenes[scene] = new ControlGamePlay();
                    _instance.cctrlMain.Content = _scenes[scene];
                    _newGame = false;
                }
                else
                    _instance.cctrlMain.Content = _scenes[scene];
            }
        }
    }
}
