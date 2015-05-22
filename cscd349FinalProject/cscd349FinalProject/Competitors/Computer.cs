using cscd349FinalProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject
{
    class Computer
    {
        private static Computer _instance;
        private const int _minEnemies = 1, _maxEnemies = 5;
        private static List<ICharacter> _enemies;

        public List<ICharacter> Enemies
        {
            get { return _enemies; }
            private set
            {
                if (value.Count > _maxEnemies)
                    throw new Exception("Too many characters for computer's enemies!");

                if(value.Count < _minEnemies)
                    throw new Exception("Too few characters for computer's enemies!");

                _enemies = value;
            }
        }

        public static Computer GetInstance()
        {
            if(_instance == null)
                _instance = new Computer();

            //_instance.Enemies = GetEnemies();

            return _instance;
        }

        private Computer()
        {
            Enemies = GetEnemies();
        }

        private static List<ICharacter> GetEnemies()
        {
            Random rand = new Random();
            int numEnemies = rand.Next(_minEnemies, _maxEnemies + 1);

            List<CharacterType> enemyTypes = new List<CharacterType>()
            {
                CharacterType.ElfDark, CharacterType.ElfEarth, CharacterType.ElfFire,
                CharacterType.ElfLight, CharacterType.ElfWater, CharacterType.ElfWind
            };

            List<ICharacter> rtn = new List<ICharacter>();
            int enemyType;
            for(int i = 0; i < numEnemies; i++)
            {
                enemyType = rand.Next(0, enemyTypes.Count); //an index
                ICharacter ichar = CharacterFactory.CreateCharacter(enemyTypes[enemyType]);
                rtn.Add(ichar);
            }

            return rtn;
        }

        public void UpdateEnemies()
        {
            _instance.Enemies = GetEnemies();
        }
    }
}
