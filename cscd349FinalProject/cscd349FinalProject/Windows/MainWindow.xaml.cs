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

        //Singleton
        public static MainWindow GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MainWindow();
                _scenes = _instance.CreateScenes();
                _instance.ChangeScene(Scene.Main);
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
            Control gameplay = new ControlGamePlay();
            //Control battle = new ControlBattle();
            Control win = new ControlWin();
            Control lose = new ControlLose();

            return new Dictionary<Scene, Control>
                   {
                       {Scene.Main, main},
                       {Scene.Character, character},
                       {Scene.CharacterSetup, null},
                       {Scene.GamePlay, gameplay},
                       {Scene.Battle, null},
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
                if (scene == Scene.CharacterSetup)
                    _instance.cctrlMain.Content = new ControlCharacterSetup();
                else if (scene == Scene.Battle)
                    _instance.cctrlMain.Content = new ControlBattle();
                else
                    _instance.cctrlMain.Content = _scenes[scene];
            }
        }
    }
}
