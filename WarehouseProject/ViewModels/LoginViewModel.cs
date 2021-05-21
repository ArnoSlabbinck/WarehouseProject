using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Controls;
using WarehouseProject.Data;


namespace WarehouseProject.ViewModels
{
    /// <summary>
    /// Link the authenticationService with the loginView
    /// </summary>
    public class LoginViewModel : PropertyChangedBase, INotifyDataErrorInfo
    {


        // After he is succesfulled login
        Dictionary<string, string> ErrorCollection = new Dictionary<string, string>();

       
        private readonly AuthenticationService authentication = new AuthenticationService();
        private readonly User user = new User(); 
        private readonly Admin admin = new Admin();
        private string _username;
        private string _realPassword;
        private string _password;
        private string _role;
        private string status;
     


        #region Properties
        [Required(ErrorMessage = "Username can't be empty")]
  
        
        public string Username {
            get 
            {

                // When the button is clicked ==> Event then check of empty property
                // If so then display the error message on the screen
                if (string.IsNullOrEmpty(_username) )
                {
                    string username = "Username";

                    if(!ErrorCollection.ContainsKey(username) )
                        ErrorCollection.Add(username, getAttibute(username));
                    


                }
                return _username;     
            }
            set 
            {
                
                _username = value;
                NotifyOfPropertyChange(() => Username);

                

            }
        }
        
        //If the  password doesn't match display message
        public string Password {
            get 
            {
                string result = null;
                if (string.IsNullOrEmpty(_password) )
                {
                    string password = "Password";
                    if (!ErrorCollection.ContainsKey(password))
                        ErrorCollection.Add(password, getAttibute(password));

                }
                else
                {
                    return _password;
                }
                return result;
            }
            set 
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);

            }
                
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
            set { status = value;
                ResetStatus();
                //Reset Status Task<
                NotifyOfPropertyChange(() => Status);
            }
        }

       

        #endregion
        public LoginViewModel()
        {
            
        }
        /// <summary>
        /// Checks the user credentials: Username and Password
        /// and makes sure they are valid. When not, gives back an 
        /// valid error
        /// </summary>
        /// <param name="parameter"></param>
        private  bool Login(string username, string password)
        {
            // Check if the textboxes are not null => Commands

            //First check if the user is not the admin 
            // First Check the user is the administrator4

            
            //Check 
            try 
            {
                
                //Raise an event that the button is present 
               


                string psswd = admin.CalculateHashPassword(password);
                //First check if the user is the admin if that the case' then continue with admin
                bool AdminOrNot = CheckOfUserAdminIs(username, psswd);
                if (AdminOrNot == true)
                    return true;
              
                User user = authentication.Login(username, password);
                if (user.IsAuthenticated == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (UnauthorizedAccessException)
            {
                Status = "Login failed! Please provide some valid credentials.";
                return false;
            }
            catch (Exception ex)
            {
                Status = string.Format("ERROR: {0}", ex.Message);
                return false;

            }
            


        }

        private async void ResetStatus()
        {
            await Task.Delay(7000);
            Status = null;
            
        }


        private bool CheckOfUserAdminIs(string username, string password)
        {
            string AdminPassword = admin.Password;
            string AdminUsername = admin.Username;
            return AdminUsername.Equals(username);

        }
       
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || (!HasErrors))
                return null;
            return new List<string>() { "Invalid credentials." };
        }

        
        public bool HasErrors { get; set; } = false;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public  bool CheckCredentials()
        {
            
            HasErrors = !Login(Username, Password);
            if (HasErrors)
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("Username"));
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("Password"));
            }
            else
            {
                return true;
            }
            Status = "Login failed! Please provide some valid credentials.";

            return false;
        }

        /// <summary>
        /// Gives back the attribute information of a given property
        /// </summary>
        /// <param name="t"></param>
        public static string getAttibute(string t)
        {
            // Get instance of the attribute.
            var attributes = typeof(User).GetProperty(t).GetCustomAttributes().Select(a => a.GetType());

            if (attributes == null)
            {
                throw new NullReferenceException("The attribute was not found.");
            }

            else
            {
                return attributes.First().Name;
            }
            
        }
        


    }


}
