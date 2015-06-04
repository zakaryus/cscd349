using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject.Characters
{
    class ACharacterComputer: ACharacter
    {
        private int _minDamage;
        private int _maxDamage;

        public int MinDamage
        {
            get { return _minDamage; }
            protected set { _minDamage = value; }
        }

        public int MaxDamage
        {
            get { return _maxDamage; }
            protected set { _maxDamage = value; }
        }

        public sealed override HitPoint Attack()
        {
            Random rand = new Random();
            int val = rand.Next(MinDamage, MaxDamage + 1);

            return new HitPoint(val);
        }
    }
}
