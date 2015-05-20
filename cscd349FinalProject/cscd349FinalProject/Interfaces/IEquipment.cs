using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject
{
    public interface IEquipment: IItem
    {
        HitPoint UseEquipment();
    }
}
