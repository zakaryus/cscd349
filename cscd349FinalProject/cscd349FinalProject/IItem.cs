using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject
{
    interface IItem
    {
        //Properties
        string Name { get; set; }
        string Description { get; set; }
        HitPoint HitPoints { get; set; }
    }
}
