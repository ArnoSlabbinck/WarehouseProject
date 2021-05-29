using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WarehouseProject.Commands;
using WarehouseProject.Data;
using WarehouseProject.EventModels;
using WarehouseProject.Views;

namespace WarehouseProject.ViewModels
{
    /// <summary>
    /// When the supervisor tries to register new employees 
    /// </summary>
    public class RegisterViewModel : INotifyPropertyChanged
    {
        DataValidationService dataValidation = new DataValidationService();
        AuthenticationService authentication = new AuthenticationService();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private IEventAggregator events;
        // Bind the data from Password Username

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public ShowEmployeesCommand ShowEmployees
        {
            get;
            set;
        }

        public SaveCommand SaveEmployee
        {
            get;
            set;
        }

        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set { 
                _lastname = value;
                RaisePropertyChanged(this, "Lastname");
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { 
                _email = value;
                RaisePropertyChanged(this, "Email");
            }
        }

        private string _firstname;
        public string FirstN
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                RaisePropertyChanged(this, "FirstN");
            }
        }





        public string Fullname()
        {
            return $"{FirstN} {Lastname}";
        
        }
        public ObservableCollection<string> WorkTypes { get; private set; }

        private  DateTime _dateOfBith;

        public DateTime DateOfBith
        {
            get { return _dateOfBith; }
            set {
                
                _dateOfBith = value;
                RaisePropertyChanged(this, "DateOfBith");
            }
        }


        public ObservableCollection<int> Salaries { get; private set; }
        public ObservableCollection<string> Genders { get; private set; }


        private  string _jobTitle;

        public string JobTitle
        {
            get { return _jobTitle; }
            set { 
                _jobTitle = value;
               
            }
        }

        private string salary;
        public string Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
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
                RaisePropertyChanged(this, "Password");

            }
        }
        
        private string _gender ;

        public string Gender
        {
            get { return _gender; }
            set { 
                _gender = value;
                
            }
        }

        private string _mobile;

        public string Mobile
        {
            get { return _mobile; }
            set { 
                _mobile = value;
                RaisePropertyChanged(this, "Mobile");
            }
        }



        private string _username;

        [Required, Range(0,5)]
        public string Username
        {
            get { return _username; }
            set { 
                _username = value;
                RaisePropertyChanged(this, "Username");

            }
        }

        public void ShowAllEmployees()
        {
            MessageBox.Show("You will see all Employees in the Database");
        }

        public string getDataNewEmployee()
        {
            return $"{FirstN}, {Lastname}, " +
                $"{Username}, {Password}, " +
                $"{Salary}, {JobTitle}, " +
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
        public RegisterViewModel(IEventAggregator eventAggregator)
        {
            ShowEmployees = new ShowEmployeesCommand(this);
            SaveEmployee = new SaveCommand(this);
            events = eventAggregator;

            events.Subscribe(this);
            

            
            WorkTypes = new ObservableCollection<string>
            {
                "SalesPerson",
                "WareHouseWorker"
            };
            Genders = new ObservableCollection<string>
            {
                "Male",
                "Female"
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


        public void Validation()
        {
            try
            {

                
               // First check if every field is not empty otherwise raise error

                Console.WriteLine(getDataNewEmployee());
                List<string> errorMembers = dataValidation.CheckRegistration(getDataNewEmployee(), authentication);
                if (errorMembers.Count > 0)
                {
                    foreach (var error in errorMembers)
                    {
                        MessageBox.Show(error);
                    }
                    
                }
                else {
                    MessageBox.Show("A new Employee is added");
                   
;
                }
                
                
                
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        
        }

        public void RaisePropertyChanged(object sender, string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }

  

    
    }
}
