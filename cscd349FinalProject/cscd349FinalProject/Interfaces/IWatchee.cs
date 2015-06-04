using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject.Interfaces
{
    public interface IWatchee
    {
        List<IWatcher> Watchers { get; } 
        void Register(IWatcher i);
        void Unregister(IWatcher i);
        void Notify();
    }
}
