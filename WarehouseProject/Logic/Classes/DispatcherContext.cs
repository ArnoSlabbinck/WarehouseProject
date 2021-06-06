using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseProject.Logic.Interfaces;

namespace WarehouseProject.Logic.Classes
{
    public class DispatcherContext : IContext
    {
        public bool IsSynchronized => throw new NotImplementedException();

        public void BeginInvoke(Action action)
        {
            throw new NotImplementedException();
        }

        public void Invoke(Action action)
        {
            throw new NotImplementedException();
        }
    }
}
