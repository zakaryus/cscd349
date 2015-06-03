using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using cscd349FinalProject.Equipment;
using cscd349FinalProject.Interfaces;
using cscd349FinalProject.Weapons;

namespace cscd349FinalProject
{
    class CharacterElfDark : ICharacter
    {
        #region Fields
        private string _name;
        private string _description;
        private HitPoint _hitpoints;
        private HitPoint _maxHitpoints;
        private IWeapon _weapon;
        private IEquipment _equipment;
        private Image _face;

        private Image _back;
        private Image _front;
        private Image _left;
        private Image _right;

        private int _minDamage;
        private int _maxDamage;

        private List<IWatcher> _watchers; 
        #endregion Fields

        #region Properties
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            private set { _description = value; }
        }

        public HitPoint HitPoints
        {
            get { return _hitpoints; }
            set
            {
                if (_maxHitpoints == null)
                    _hitpoints = value;
                else if (value > _maxHitpoints)
                    _hitpoints = _maxHitpoints;
                else if (value.Value <= 0)
                {
                    _hitpoints.Value = 0;
                    Die();
                }
                else
                    _hitpoints = value;
            }
        }

        public HitPoint MaxHitPoints
        {
            get { return _maxHitpoints; }
            set { _maxHitpoints = value; }
        }

        public IWeapon Weapon
        {
            get { return _weapon; }
            set { _weapon = value; }
        }

        public IEquipment Equipment
        {
            get { return _equipment; }
            set { _equipment = value; }
        }

        public System.Windows.Controls.Image Face
        {
            get { return _face; }
            private set { _face = value; }
        }


        public System.Windows.Controls.Image Front
        {
            get { return _front; }
            private set { _front = value; }
        }

        public System.Windows.Controls.Image Back
        {
            get { return _back; }
            private set { _back = value; }
        }

        public System.Windows.Controls.Image Right
        {
            get { return _right; }
            private set { _right = value; }
        }

        public System.Windows.Controls.Image Left
        {
            get { return _left; }
            private set { _left = value; }
        }

        #endregion Properties

        #region Constructor

        public CharacterElfDark()
        {
            Name = "Dark Elf";
            Description = "An evil elf character.";
            MaxHitPoints = HitPoints = new HitPoint(100);
            Weapon = new WeaponNull();
            Equipment = new EquipmentNull();
            Face = new Image();
            _minDamage = 20;
            _maxDamage = 45;
            Face.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Images/Faces/BadFaces/CharacterElfDarkFace.png");

            Front = new Image();
            Front.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/DarkElf/DarkElfFront.png");
            Back = new Image();
            Back.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/DarkElf/DarkElfBack.png");
            Left = new Image();
            Left.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/DarkElf/DarkElfLeft.png");
            Right = new Image();
            Right.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Sprites/DarkElf/DarkElfRight.png");
        
            _watchers = new List<IWatcher>();
        }
        #endregion Constructor

        #region Methods
        public HitPoint Attack()
        {
            Random rand = new Random();
            int val = rand.Next(_minDamage, _maxDamage + 1);

            return new HitPoint(val);
        }

        public void Die()
        {
            //I'm dead
            //do something
            Notify();
        }
        #endregion Methods



        public void Register(IWatcher i)
        {
            if(!_watchers.Contains(i))
                _watchers.Add(i);
        }

        public void Unregister(IWatcher i)
        {
            if (_watchers.Contains(i))
                _watchers.Remove(i);
        }

        public void Notify()
        {
            foreach(IWatcher i in _watchers)
                i.BeNotified(this);
        }
    }
}
