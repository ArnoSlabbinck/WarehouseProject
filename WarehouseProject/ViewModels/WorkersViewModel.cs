using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WarehouseModels;
using WarehouseProject.Data;
using System.Windows;
using System.Windows.Controls;
using WarehouseProject.Views;
using System.Windows.Data;
using System.Windows.Media;
using Caliburn.Micro;
using System.Collections.Generic;

namespace WarehouseProject.ViewModels
{
    public class WorkersViewModel : BaseViewModel
    {
        private LookUpDataService dataEmployee = new LookUpDataService();
        
        public BindableCollection<newEmployeeParams> Worker{get; private set;}

        private List<newEmployeeParams> newEmployees; 

        public List<newEmployeeParams> NewEmployees
        {
            get { return newEmployees; }
            set { newEmployees = value; }
        }
     
      
        private newEmployeeParams employeeParams;

        public newEmployeeParams EmployeeParams
        {
            get { return employeeParams; }
            set { employeeParams = value; }
        }

        private int id = 0;

        public int Id
        {
            get { return id; }
            set { 
                
                id = value;
                RaisePropertyChanged(this, id.ToString());
            }
        }
        // Dat moet geinstalliseerd worden bij de start 


        private int age;

        public int Age
        {
            get { return age; }
            set { 
                age = value;
                RaisePropertyChanged(this, age.ToString());
            }

        }
        
        public WorkersViewModel()
        {
            GetAllEmployees();
            Worker = new BindableCollection<newEmployeeParams>(newEmployees);

        }

        private void GetAllEmployees()
        {
            int id = 1;
            newEmployees = new List<newEmployeeParams>();
            // Every time a new employee is displayed
            foreach(var newEmployee in dataEmployee.GiveAllEmployees())
            {
                employeeParams = new newEmployeeParams();
                employeeParams.Id = id;
                employeeParams.FirstName = newEmployee.FirstName;
                employeeParams.LastName = newEmployee.LastName;
                employeeParams.JobTitle = newEmployee.JobTitle;
                employeeParams.Email = newEmployee.Email;
                employeeParams.Gender = newEmployee.Gender;
                employeeParams.Age = CalculateAge(employeeParams.BirthDate);
                NewEmployees.Add(employeeParams);
                id++;
            }

            Console.WriteLine(NewEmployees.Count);
        }

        /// <summary>
        /// Calculates the age from a birthDateObject
        /// </summary>
        /// <param name="birthDateTime"></param>
        /// <returns></returns>
        private int CalculateAge(DateTime birthDateTime)
        {
            var today = DateTime.Today;
            Console.WriteLine(birthDateTime);

            bool CanShowAge = int.TryParse(
                (today.Year - birthDateTime.Year)
                .ToString(), out age);
            if (CanShowAge == true)
                return age;
            else 
                throw new InvalidCastException("Fault in birthday variable to calculate the age");
                
            
            
        }
        /// <summary>
        /// Makes a new Datatemplate to display a new employee
        /// </summary>
        private void GenerateANewDataTemplate(newEmployeeParams newEmployeeParams)
        {
            
            //Makes a new DataTemplate object every time a new employee is asked
            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactory.SetValue(TextBlock.TextProperty, new Binding(".")); // Here
            textBlockFactory.SetValue(TextBlock.BackgroundProperty, Brushes.Red);
            textBlockFactory.SetValue(TextBlock.ForegroundProperty, Brushes.Wheat);
            textBlockFactory.SetValue(TextBlock.FontSizeProperty, 18.0);

            var template = new DataTemplate();
            template.VisualTree = textBlockFactory;


        }


    }

}
