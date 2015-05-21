using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cscd349FinalProject.Items;

namespace cscd349FinalProject
{
    class InventoryManager
    {
        private static InventoryManager _instance;
        private static List<IInventory> _allInventory;

        public List<IInventory> AllInventory
        {
            get { return _allInventory; }
            private set { _allInventory = value; }
        }

        public static InventoryManager getInstance()
        {
            if (_instance == null)
                _instance = new InventoryManager();

            return _instance;
        }

        private InventoryManager()
        {
            AllInventory = new List<IInventory>
                            {
                                new ItemHealthPotionBig(),
                                new ItemHealthPotionSmall()
                            };
        }
    }
}
