using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProject.Logic.Interfaces
{
    /// <summary>
    /// Abstracted Version of Dispatcher Object to use Multi-Threading
    /// </summary>
    public interface IContext
    {
        bool IsSynchronized { get; }
        void Invoke(Action action);
        void BeginInvoke(Action action);
    }
}
