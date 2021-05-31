using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseProject.ViewModels;

namespace WarehouseProject
{
    public class ShellViewModel : Screen
    {
        private IEventAggregator _events;
        private IWindowManager manager;
        public ShellViewModel(IEventAggregator events, IWindowManager windowManager, LoginViewModel loginVM, EmployeeViewModel _registration)
        {
            manager = windowManager;
            _events = events;
            Login = loginVM;
            registration = _registration;
            windowManager.ShowDialog(Login);

            
        }
        public LoginViewModel Login { get; }

        public EmployeeViewModel registration { get; }
    }
}
