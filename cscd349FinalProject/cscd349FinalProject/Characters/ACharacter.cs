using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using cscd349FinalProject.Interfaces;

namespace cscd349FinalProject.Characters
{
    abstract class ACharacter: ICharacter
    {
        #region Fields
        private string _name;
        private string _description;
        private bool _dead;
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
            protected set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            protected set { _description = value; }
        }

        public bool Dead
        {
            get { return _dead; }
            protected set { _dead = value; }
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

        public Image Face
        {
            get { return _face; }
            protected set { _face = value; }
        }

        public Image Front
        {
            get { return _front; }
            protected set { _front = value; }
        }

        public Image Back
        {
            get { return _back; }
            protected set { _back = value; }
        }

        public Image Right
        {
            get { return _right; }
            protected set { _right = value; }
        }

        public Image Left
        {
            get { return _left; }
            protected set { _left = value; }
        }

        public List<IWatcher> Watchers
        {
            get { return _watchers; }
            protected set { _watchers = value; }
        }
        #endregion Properties

        #region Constructor
        public ACharacter(){ }
        #endregion Constructor

        #region Methods

        public abstract HitPoint Attack();

        public void Die()
        {
            //I'm dead
            //do something
            Dead = true;
            Notify();
        }
        
        public void Register(IWatcher i)
        {
            if(Watchers == null)
                throw new NullReferenceException();

            if (!Watchers.Contains(i))
                _watchers.Add(i);
        }

        public void Unregister(IWatcher i)
        {
            if (Watchers == null)
                throw new NullReferenceException();

            if (_watchers.Contains(i))
                _watchers.Remove(i);
        }

        public void Notify()
        {
            if (Watchers == null)
                throw new NullReferenceException();

            foreach (IWatcher i in Watchers)
                i.BeNotified(this);
        }
        #endregion Methods
    }
}
