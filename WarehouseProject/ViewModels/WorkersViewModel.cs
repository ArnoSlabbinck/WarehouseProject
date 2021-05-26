using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WarehouseModels;
using WarehouseProject.Data;

namespace WarehouseProject.ViewModels
{
    public class WorkersViewModel : INotifyPropertyChanged
    {
        /*
         * I need to pull data from the the LookupDataService
         * I don't need to pull data from the user but send data to the view
         * How => OneTime Binding
         * I use DataTemplate to make a object 
         * I don't know of much Employees are in the database
         * I need a way to list the scope => If after 4 employees => Scrollbar maken
         * 
         * Loop through every employee object you get back from lookup data service 
         * Then Make an DataTemplate every time  you loop through one employee object
         * If the Height of window is becomes to small  =>  Scrollbar
         * 
         * Scrollbar  => Vergroten van de hoogte van window
         * Je weet niet hoeveel Employees er zijn
         * 3 Employees per Regel
         * Tell aantal employees in lijst
         * Vergroot de hoogte van uw window per keer elke keer 
         * ScrollViewer gebruiken 
         * 
         * Display data  => OneTime binding, Set the before the view is called
         * 
         * I need to a command to show the employee => Get the account of the employee => Send Employee object to the Account object 
         * Via EventModel You can pass that object into the event
         * EventAggregator
         */
        private LookUpDataService dataEmployee = new LookUpDataService();
        private ObservableCollection<Employee> employees;
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }


        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Fullname()
        {
            return $"{firstName} {LastName}";
        }


        private string email;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private int salary;

        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        // Dat moet geinstalliseerd worden bij de start 


        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public WorkersViewModel()
        {


        }

        private void GetAllEmployees()
        {
            // Every time a new employee is displayed
            // Add the idd
            throw new NotImplementedException();
            
        }


        private int CalculateAge(DateTime birthDateTime)
        {
            int age = 0;
            //Take the year of Datetime now 
            // Take the birthyear
            // Substract now from birth
            // Return ageµµ
            bool CanShowAge = int.TryParse(
                (DateTime.Now.Year - birthDateTime.Year)
                .ToString(), out age);
            if (CanShowAge == true)
            {
                return age;
            }
            else {
                throw new InvalidCastException("Fault in birthday variable to calculate the age");
                
            }
            
        }
    }
}
