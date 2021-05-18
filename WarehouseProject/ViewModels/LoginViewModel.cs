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
    class LoginViewModel : DataPropertyChanged
    {
        
       // After he is succesfulled login
        private readonly AuthenticationService authentication;
        private readonly User user;
        private readonly Admin admin;
        private readonly DelegateCommand _loginCommand;
        private readonly DelegateCommand _logoutCommand;
        private string _username;
        private string _password;
        private string _role;
        private string name;
        private string status;


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
        /// <summary>
        /// Displays Error when authentication fails
        /// </summary>
        public string Status { 
            get { return status; }
            set { status = value; }
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
        /// check is the user or Admin is authenticated
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

        private bool CanLogin(object paramater)
        {
            // Check of the inputfields are not empty
             
        }
        /// <summary>
        /// Checks the user credentials: Username and Password
        /// and makes sure they are valid. When not, gives back an 
        /// valid error
        /// </summary>
        /// <param name="parameter"></param>
        private void Login(object parameter)
        {
            // Check if the textboxes are not null => Commands

            //First check if the user is not the admin 
            // First Check the user is the administrator

            try 
            {
                User user = authentication.Login(Username, Password);

            }
            catch (UnauthorizedAccessException)
            {
                Status = "Login failed! Please provide some valid credentials.";
            }
            catch (Exception ex)
            {
                Status = string.Format("ERROR: {0}", ex.Message);
            }

        }


        #region Commands
        public DelegateCommand LoginCommand { get { return _loginCommand; } }

        public DelegateCommand LogoutCommand { get { return _logoutCommand; } }

        #endregion


       
        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            throw new NotImplementedException();
            return base.Equals(obj);
        }

    }


}
