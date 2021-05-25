using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseProject.ViewModels;


namespace WarehouseProject.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginViewModel login;
        public event EventHandler CanExecuteChanged;
        public LoginCommand(LoginViewModel _loginViewModel)
        {
            login = _loginViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await login.CheckCredentials();
            
        }
    }
}
