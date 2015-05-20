using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using cscd349FinalProject.Weapons;

namespace cscd349FinalProject
{
    class CharacterMagicianMale : ICharacter
    {
        #region Fields
        private string _name;
        private string _description;
        private HitPoint _hitpoints;
        private HitPoint _maxHitpoints;
        private IWeapon _weapon;
        private List<IEquipment> _equipment;
        private Image _face;
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
            set { _hitpoints = value; }
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

        public List<IEquipment> Equipment
        {
            get { return _equipment; }
            set { _equipment = value; }
        }

        public System.Windows.Controls.Image Face
        {
            get { return _face; }
            private set { _face = value; }
        }
        #endregion Properties

        #region Constructor

        public CharacterMagicianMale()
        {
            Name = "Male Magician";
            Description = "A mystical character.";
            MaxHitPoints = HitPoints = new HitPoint(100);
            Weapon = new WeaponNull();
            Equipment = null;
            Face = new Image();
            Face.Source = HelperImages.UriStringToImageSource("pack://application:,,,/Images/Faces/GoodFaces/CharacterMagicianMaleFace.png");
        }
        #endregion Constructor

        #region Methods
        public HitPoint Attack()
        {
            return _weapon.UseWeapon();
        }

        public void Die()
        {
            //I'm dead
            //do something
        }
        #endregion Methods
    }
}
