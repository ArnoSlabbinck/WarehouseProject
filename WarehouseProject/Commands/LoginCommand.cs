using Caliburn.Micro;
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
        private IEventAggregator events;
        public LoginCommand(LoginViewModel _loginViewModel, IEventAggregator _events)
        {
            login = _loginViewModel;
            events = _events;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            
            bool loggedIn = await login.CheckCredentials();
            WindowManager window = new WindowManager();
            if (loggedIn == true)
                login.PublishMessageAdmin();
                window.ShowDialog(new RegisterViewModel(events));

        }
    }
}
