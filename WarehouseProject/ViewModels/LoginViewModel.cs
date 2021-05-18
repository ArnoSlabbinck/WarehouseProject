using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseProject.Data;

namespace WarehouseProject.ViewModels
{
    //Link the authenticationService with the loginView
    class LoginViewModel : INotifyPropertyChanged
    {
        
       // After he is succesfulled login
        private readonly AuthenticationService authentication;
        private readonly DelegateCommand _loginCommand;
        private readonly DelegateCommand _logoutCommand;
        private string _username;
        private string _password;
        private string _role;
        private string name;

        #region Properties

        public string Username {
            get { return _username; }
            set { _username = value; NotifyPropertyChanged("Username"); }
        }

        public string Password {
            get { return _password; }
            set { _password = value; NotifyPropertyChanged("Password"); }
        }

        public string Role {
            get { return _role; }
            set { _role = value; NotifyPropertyChanged("Role"); }
        }
        #endregion

        public LoginViewModel(AuthenticationService _authentication)
        {
            authentication = _authentication;
            _loginCommand = new DelegateCommand(Login, CanLogin);
            _logoutCommand = new DelegateCommand(Logout, CanLogout);
        }
        // Make a second class admin
        // Check first of the user is the admin 
        // 

        /// <summary>
        /// check
        /// </summary>
        /// <returns></returns>
        private bool CanLogout()
        {
           
            throw new NotImplementedException();
        }

        private void Logout()
        {
            throw new NotImplementedException();
        }

        private bool CanLogin()
        {
            // Check of the inputfields are not empty
            throw new NotImplementedException();
        }

        private void Login()
        {
            throw new NotImplementedException();
        }


        #region Commands
        public DelegateCommand LoginCommand { get { return _loginCommand; } }

        public DelegateCommand LogoutCommand { get { return _logoutCommand; } }

        #endregion


        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
