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
        public ShellViewModel(IWindowManager windowManager, LoginViewModel login)
        {
            Login = login;
            
        }
        public LoginViewModel Login { get; }
    }
}
