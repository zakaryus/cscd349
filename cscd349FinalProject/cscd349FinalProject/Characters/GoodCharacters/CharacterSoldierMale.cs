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
    class CharacterSoldierMale : ACharacterPlayer
    {
        public CharacterSoldierMale()
        {
            Name = "Male Soldier";
            Description = "A battle-tested character.";
            Dead = false;
            MaxHitPoints = HitPoints = new HitPoint(100);
            Weapon = new WeaponNull();
            Equipment = new EquipmentNull();
            Face = new Image();
            Face.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Images/Faces/GoodFaces/CharacterSoldierMaleFace.png");

            Front = new Image();
            Front.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/SoldierMale/SoldierFront.png");
            Back = new Image();
            Back.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/SoldierMale/SoldierBack.png");
            Left = new Image();
            Left.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/SoldierMale/SoldierLeft.png");
            Right = new Image();
            Right.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/SoldierMale/SoldierRight.png");
        
            Watchers = new List<IWatcher>();
        }
    }
}
