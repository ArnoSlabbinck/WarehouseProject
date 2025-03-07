﻿using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Controls;
using WarehouseProject.Commands;
using WarehouseProject.Data;
using WarehouseProject.EventModels;
using WarehouseProject.Views;

namespace WarehouseProject.ViewModels
{
    /// <summary>
    /// Link the authenticationService with the loginView
    /// </summary>
    public class LoginViewModel : BaseViewModel 
    {


        // After he is succesfulled login
        Dictionary<string, string> ErrorCollection = new Dictionary<string, string>();

       
        private readonly AuthenticationService authentication = new AuthenticationService();
        private  User user = new User(); 
        private readonly Admin admin = new Admin();
        private readonly WindowManager windowManager = new WindowManager();
        private readonly MainWindowViewModel mainWindow;
        private string _username;
        private string _realPassword;
        private string _password;
        private string _role;
        private string status;


        private IEventAggregator events;

        

        public LoginCommand LoginButton
        {
            get;
            set;
        }
            
        public ErrorCommand ErrorCommand
        {
            get;
            set;
        }

        #region Properties
        [Required(ErrorMessage = "Username can't be empty")]

        private string errors;

        public string Errors
        {
            get { return errors; }
            set
            {
                errors = value;
                OnPropertyChanged(nameof(Errors));
            }
        }

        private bool _IsDialogOpen;
        public bool IsDialogOpen
        {
            get { return _IsDialogOpen; }
            set
            {
                _IsDialogOpen = value;
                OnPropertyChanged(nameof(IsDialogOpen));

            }
        }
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
                OnPropertyChanged(nameof(Username));



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
                OnPropertyChanged(nameof(Password));

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
                OnPropertyChanged(nameof(Status));
            }
        }

       

        #endregion
        public LoginViewModel(IEventAggregator _events, MainWindowViewModel mainWindow, EmployeeViewModel register, AccountViewModel account, ContactViewModel error )
        {
            this.mainWindow = mainWindow;
            events = _events;
            events.Subscribe(this);
            LoginButton = new LoginCommand(this, events, windowManager, register, mainWindow, account);
            ErrorCommand = new ErrorCommand(this);
            
        }
        /// <summary>
        /// Checks the user credentials: Username and Password
        /// and makes sure they are valid. When not, gives back an 
        /// valid error
        /// </summary>
        /// <param name="parameter"></param>
        private  Object Login(string username, string password)
        {
            // Check if the textboxes are not null => Commands

            //First check if the user is not the admin 
            // First Check the user is the administrator4

            
            //Check 
            try 
            {
                
                //Raise an event that the button is 
                string psswd = admin.CalculateHashPassword(password);
                //First check if the user is the admin if that the case' then continue with admin
                bool AdminOrNot = CheckOfUserAdminIs(username, psswd);

                if (AdminOrNot == true)
                {

                    Console.WriteLine($"Welcome {admin.Name}");
                    return admin;

                }
                    
                    
              
                user = authentication.Login(username, password);
                if (user.IsAuthenticated == false)
                {
                    return null;
                }
                else
                {
                    Console.WriteLine("You are logged in");
                    
                    return user;
                }  
            }
            catch (UnauthorizedAccessException)
            {
                Status = "Login failed! Please provide some valid credentials.";
                return null;
            }
            catch (Exception ex)
            {
                Status = string.Format("ERROR: {0}", ex.Message);
                return null;

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
            return AdminUsername.Equals(username) && AdminPassword.Equals(password);

        }
       
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || (!HasErrors))
                return null;
            return new List<string>() { "Invalid credentials." };
        }

        
        public bool HasErrors { get; set; } = false;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public async Task<bool> CheckCredentials()
        {
            
            HasErrors = await Task.Run(() => Login(Username, Password) !=  null ? false : true);
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

        public void OnShowDialog()
        {
            Errors = "A message has been send to the supervisor. He will recreate your password";
            IsDialogOpen = true;
        }



        /// <summary>
        /// Sent a admin or user instance to the main application after they
        /// have succesfully logged in
        /// </summary>
        /// <param name="username"></param>
        public  void PublishMessageAdminOrUser(string username)
        {
            if(username == admin.Username)
                Task.Run(() =>  events.PublishOnUIThreadAsync(new UserLoginEvent(admin)));
            else
                Task.Run(() => events.PublishOnUIThreadAsync(new UserLoginEvent(user)));
        }

    
    
    }


}
