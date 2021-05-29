using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WarehouseProject.Commands;
using WarehouseProject.Views;

namespace WarehouseProject.ViewModels
{
    public class MainWindowViewModel
    {
        private RegisterViewModel register;

        public RegisterViewModel Register
        {
            get;
            set;
        }

        public ShutdownCommand Shutdown
        {
            get;
            set;
        }

        public MainWindowViewModel(IEventAggregator eventaggretor)
        {
            
            Shutdown = new ShutdownCommand();

        
        }
    }
}
