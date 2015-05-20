using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace cscd349FinalProject
{
    public interface IItem
    {
        //Properties
        string Name { get; }
        string Description { get; }
        HitPoint HitPoints { get; }
        Image Icon { get; }
    }
}
