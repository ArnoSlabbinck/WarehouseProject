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
        private EmployeeViewModel register;
        public event EventHandler CanExecuteChanged;
        private MainWindowViewModel mainw;
        private AccountViewModel account;
        private WindowManager windowManager;
        private IEventAggregator events;
        public LoginCommand(LoginViewModel _loginViewModel, IEventAggregator _events,
            WindowManager windowManager,
            EmployeeViewModel registerView,
            MainWindowViewModel mainWindow,
            AccountViewModel accountView)
        {
            login = _loginViewModel;
            this.windowManager = windowManager;
            events = _events;
            register = registerView;
            mainw = mainWindow;
            account = accountView;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            
            bool loggedIn = await login.CheckCredentials();
            if (loggedIn == true)
            {
                var username = parameter as string;
                login.PublishMessageAdminOrUser(username);
                windowManager.ShowDialog(new MainWindowViewModel(events, register, account));

            }
                

        }
    }
}
