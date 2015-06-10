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
        Main, Character, CharacterSetup, GamePlay, Battle, Win, Lose, Restart
    }

    public partial class MainWindow : Window
    {
        private static MainWindow _instance = null;
        private static Dictionary<Scene, Control> _scenes = null;
        private static bool _newGame;
        private Scene _currentScene;

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
            Control restart = new Control();

            return new Dictionary<Scene, Control>
                   {
                       {Scene.Main, main},
                       {Scene.Character, character},
                       {Scene.CharacterSetup, null},    //null for a new character setup on every scene change
                       {Scene.GamePlay, null},      //null so that a new map is created on each gameplay
                       {Scene.Battle, null},    //null for a new battle on every scene change
                       {Scene.Win, win},
                       {Scene.Lose, lose},
                       {Scene.Restart, restart}
                   };
        }

        public void ChangeScene(Scene scene)
        {
            if (_scenes == null)
                return;

            if (_scenes.ContainsKey(scene))
            {
                //reset the maze after win/lose
                if (scene == Scene.Win || scene == Scene.Lose || scene == Scene.Restart)
                    _newGame = true;

                _currentScene = scene;

                if (scene == Scene.CharacterSetup)
                    _instance.cctrlMain.Content = new ControlCharacterSetup();
                else if (scene == Scene.Battle)
                    _instance.cctrlMain.Content = new ControlBattle();
                else if (scene == Scene.Restart)
                {
                    _currentScene = Scene.Main;
                    _instance.cctrlMain.Content = new ControlMain();
                }
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

        private void miQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void miNew_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().ChangeScene(Scene.Restart);
        }

        private void miInstructions_Click(object sender, RoutedEventArgs e)
        {
            String msg = String.Empty;

            if (_currentScene == Scene.Main)
                msg = "This is the main scene. Begin a new game, or quit.";
            else if (_currentScene == Scene.Character)
                msg = "This is the character selection scene. Select three characters to begin the game.";
            else if (_currentScene == Scene.CharacterSetup)
                msg = "This is the character setup scene. Drag and drop one weapon and one armor on to " +
                        "each of your characters. If you change your mind about an item, drag a new one " +
                        "to replace it, and the old one will return to the selection list.";
            else if (_currentScene == Scene.GamePlay)
                msg = "This is the game play scene. Navigate your character throught the maze towards " +
                        "the exit door. Your character can be moved using the WASD keys. Collect items " +
                        "to help you in your battles. When you encounter an enemy you will battle them " +
                        "using the characters you selected.";
            else if (_currentScene == Scene.Battle)
                msg = "This is the battle scene. Drag from one of your characters to an enemy in order " +
                        "to attack. After you have attacked with all of your characters, the enemies will " +
                        "take their turns attacking. Use your collected items during your turn to heal your " +
                        "characters. If all of your characters are defeated, you will lose the game. If you " +
                        "win, you will return to the game play scene.";
            else if (_currentScene == Scene.Lose)
                msg = "This is the lose scene. You have lost the game, return to the main scene to play again!";
            else if (_currentScene == Scene.Win)
                msg = "This is the win scene. Congratulations! You have completed \"Heroes and Monsters\". " +
                        "Return to the main scene to play again!";
            else
                msg = "How did you get here?";

            MessageBox.Show(msg, "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void miAbout_Click(object sender, RoutedEventArgs e)
        {
            String msg = "Heroes and Monsters\n\n" +
                            "CSCD 349 - Design Patterns\n" +
                            "Final Project\n\n" +
                            "Created by: \n" +
                            "\tGiang Bui\n" +
                            "\tTony Moua\n" +
                            "\tZak Steele\n\n" +
                            "Notice:\n" +
                            "\tArt by Charles Gabriel. Commissioned by OpenGameArt.org (http://opengameart.org)\n" +
                            "\tArt by Antifarea. Commissioned by OpenGameArt.org (http://opengameart.org)";
            MessageBox.Show(msg, "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
