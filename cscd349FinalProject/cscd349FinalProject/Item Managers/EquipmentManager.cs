using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cscd349FinalProject.Equipment;
using cscd349FinalProject.Weapons;

namespace cscd349FinalProject
{
    class EquipmentManager
    {

         private static EquipmentManager _instance;
        private static List<IEquipment> _allEquipments;

        public List<IEquipment> AllEquipments
        {
            get { return _allEquipments; }
            private set { _allEquipments = value; }
        }

        public static EquipmentManager GetInstance()
        {
            if(_instance == null)
                _instance = new EquipmentManager();

            return _instance;
        }

        private EquipmentManager()
        {
            AllEquipments = new List<IEquipment>
                         {
                             new EquipmentSilverArmor(),
                             new EquipmentBrownArmor(),
                             new EquipmentLeatherArmor(),
                             new EquipmentPlatinumArmor(),
                             new EquipmentGoldArmor(),
                             
                         };
        }
    }
}
