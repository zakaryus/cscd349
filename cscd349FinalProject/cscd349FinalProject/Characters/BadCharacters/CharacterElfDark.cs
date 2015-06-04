﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using cscd349FinalProject.Characters;
using cscd349FinalProject.Equipment;
using cscd349FinalProject.Interfaces;
using cscd349FinalProject.Weapons;

namespace cscd349FinalProject
{
    class CharacterElfDark : ACharacterComputer
    {
        public CharacterElfDark()
        {
            Name = "Dark Elf";
            Description = "An evil elf character.";
            Dead = false;
            MaxHitPoints = HitPoints = new HitPoint(100);
            Weapon = new WeaponNull();
            Equipment = new EquipmentNull();
            Face = new Image();
            MinDamage = 20;
            MaxDamage = 45;
            Face.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Images/Faces/BadFaces/CharacterElfDarkFace.png");

            Front = new Image();
            Front.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/DarkElf/DarkElfFront.png");
            Back = new Image();
            Back.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/DarkElf/DarkElfBack.png");
            Left = new Image();
            Left.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/DarkElf/DarkElfLeft.png");
            Right = new Image();
            Right.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/DarkElf/DarkElfRight.png");
        
            Watchers = new List<IWatcher>();
        }
    }
}
