using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cscd349FinalProject.Interfaces;

namespace cscd349FinalProject
{
    class Player
    {
        private static Player _instance = null;
        private static List<ICharacter> _allies;
        private static List<IInventory> _inventory; 

        public List<ICharacter> Allies
        {
            get { return _allies; }
            set
            {
                if(value.Count > 3)
                    throw new Exception("Too many characters for player's allies!");

                if(value.Count < 1)
                    throw new Exception("Too few characters for player's allies!");

                _allies = value;
            }
        }

        public List<IInventory> Inventory
        {
            get { return _inventory; }
        }

        public static Player GetInstance()
        {
            if(_instance == null)
                _instance = new Player();

            return _instance;
        }

        public void AddInventoryItem(IInventory item)
        {
            _inventory.Add(item);
        }

 
    }
}
