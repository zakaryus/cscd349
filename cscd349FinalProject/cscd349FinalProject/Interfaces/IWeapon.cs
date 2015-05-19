using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace cscd349FinalProject
{
    public interface IWeapon: IItem
    {
        Image Icon { get; }
        HitPoint UseWeapon();
    }
}
