using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseProject.Data;

namespace WarehouseProject.ViewModels
{
    /// <summary>
    /// When the supervisor tries to register new employees 
    /// </summary>
    public class RegistrationViewModel : PropertyChangedBase
    {
        DataValidationService dataValidation = new DataValidationService();
        AuthenticationService authentication = new AuthenticationService();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        // Bind the data from Password Username


        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set { 
                _lastname = value;
                NotifyOfPropertyChange(() => Lastname);
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { 
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }

        private string _firstname;
        public string FirstN
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                NotifyOfPropertyChange(() => FirstN);
            }
        }





        public string Fullname()
        {
            return $"{FirstN} {Lastname}";
        
        }
        public ObservableCollection<string> WorkTypes { get; private set; }

        private DateTime _dateOfBith;

        public DateTime DateOfBith
        {
            get { return _dateOfBith; }
            set {
                _dateOfBith = value;
                NotifyOfPropertyChange(() => DateOfBith);
            }
        }


        public ObservableCollection<int> Salaries { get; private set; }



        private string _jobTitle;

        public string JobTitle
        {
            get { return _jobTitle; }
            set { 
                _jobTitle = value;
                NotifyOfPropertyChange(() => JobTitle);
            }
        }



        private string _password;
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*?&])([a-zA-Z0-9@$!%*?&]{8,})$",
            ErrorMessage = "Password has next Requirements:" +
            "At least 8 characters long," +
            "One lowercase, one uppercase, one number and one special character" +
            " No whitespaces")]
        public string Password
        {
            get { return _password; }
            set { 
                _password = value;
                NotifyOfPropertyChange(() => Password);

            }
        }

        private string _gender ;

        public string Gender
        {
            get { return _gender; }
            set { 
                _gender = value;
                NotifyOfPropertyChange(() => Gender);
            }
        }

        private string _mobile;

        public string Mobile
        {
            get { return _mobile; }
            set { 
                _mobile = value;
                NotifyOfPropertyChange(() => Mobile);
            }
        }



        private string _username;

        [Required, Range(0,5)]
        public string Username
        {
            get { return _username; }
            set { 
                _username = value;
                NotifyOfPropertyChange(() => Username);

            }
        }

        public string getDataNewEmployee()
        {
            return $"{FirstN}, {Lastname}, " +
                $"{Username}, {Password}, " +
                $"{Salaries}, {WorkTypes}, " +
                $"{Email}, {Gender}," +
                $"{DateOfBith}";
        
        }
        //Validation:  
        /*
         * Password needs to At least 8 characters long," +
            "One lowercase, one uppercase, one number and one special character" +
            " No whitespaces
        *
        * Username needs to be at least 5 characters
        * 
        * Check Validation: => 
         */
        public RegistrationViewModel()
        {
            WorkTypes = new ObservableCollection<string>
            {
                "SalesPerson",
                "WareHouseWorker"
            };

            Salaries = new ObservableCollection<int>();
            Salaries = newSalaries(Salaries);
        }

        /// <summary>
        /// Makes the salaries all employees get
        /// </summary>
        /// <param name="Salaries"></param>
        /// <returns></returns>
        private ObservableCollection<int> newSalaries(ObservableCollection<int> Salaries)
        {
            //Every Salary should be between 20 000 - 60 000
            // Start at 20 000  count up 1000 until you get to 60 000
            int minSalary = 20000;
            int maxSalary = 60000;
            
            while (minSalary <= maxSalary)
            {
                Salaries.Add(minSalary);
                minSalary += 1000;
            }

            return Salaries;
        }


        public bool Validation()
        {
            try
            {
                Console.WriteLine(getDataNewEmployee());
                string errorMembers = dataValidation.CheckRegistration(getDataNewEmployee(), authentication);
                if (!string.IsNullOrEmpty(errorMembers))
                {
                    return true;
                }
                else {
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(errorMembers));
                    return false;
                }
                
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);       
                return false;
            }
        
        }






    }
}
