using Caliburn.Micro;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WarehouseProject.Data;

namespace WarehouseProject.ViewModels
{
    /// <summary>
    /// Link the authenticationService with the loginView
    /// </summary>
    public class LoginViewModel : PropertyChangedBase
    {

        // After he is succesfulled login

       
        private readonly AuthenticationService authentication = new AuthenticationService();
        private readonly User user;
        private readonly Admin admin;
        private string _username;
        private string _password;
        private string _role;
        private string name;
        private string status;


        #region Properties
        [Required(ErrorMessage = "Username can't be empty")]
       
        public string Username {
            get 
            {
                return _username;     
            }
            set 
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);

            }
        }
        [Required(ErrorMessage = "Password can't be empty")]
        //If the  password doesn't match display message
        public string Password {
            get { return _password; }
            set { 
                _password = value;
                NotifyOfPropertyChange(() => Password); }
        }

        public string Role {
            get { return _role; }
            set { _role = value;  }
        }
        /// <summary>
        /// Displays Error when authentication fails
        /// </summary>
        public string Status { 
            get { return status; }
            set { status = value; }
        }

        

        #endregion
        public LoginViewModel()
        {
            
        }


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

        public bool CanLogin(string username, string password)
        {
            return !String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password);
        }
        /// <summary>
        /// Checks the user credentials: Username and Password
        /// and makes sure they are valid. When not, gives back an 
        /// valid error
        /// </summary>
        /// <param name="parameter"></param>
        private string Login(object parameter)
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
            return "hallo";

        }


    }


}
