using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseProject.ViewModels;

namespace WarehouseProject.Commands
{
    public class ErrorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private LoginViewModel login;

        public ErrorCommand(LoginViewModel loginView)
        {
            login = loginView; 
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            login.OnShowDialog(); 
        }
    }
}
