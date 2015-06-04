using System;
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
    class CharacterElfFire : ACharacterComputer
    {
        public CharacterElfFire()
        {
            Name = "Fire Elf";
            Description = "A fire breathing elf character.";
            Dead = false;
            MaxHitPoints = HitPoints = new HitPoint(100);
            Weapon = new WeaponNull();
            Equipment = new EquipmentNull();
            Face = new Image();
            MinDamage = 20;
            MaxDamage = 45;
            Face.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Images/Faces/BadFaces/CharacterElfFireFace.png");

            Front = new Image();
            Front.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/FireElf/FireElfFront.png");
            Back = new Image();
            Back.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/FireElf/FireElfBack.png");
            Left = new Image();
            Left.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/FireElf/FireLeft.png");
            Right = new Image();
            Right.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/FireElf/FireElfRight.png");

            Watchers = new List<IWatcher>();
        }
    }
}
