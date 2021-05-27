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

namespace WarehouseProject.ViewModels
{
    public class WorkersViewModel : INotifyPropertyChanged
    {
        private LookUpDataService dataEmployee = new LookUpDataService();
        private newEmployeeParams employee = new newEmployeeParams();
        private ObservableCollection<Employee> employees;
        private WorkersView workersView = new WorkersView();
     
        public string Fullname(newEmployeeParams newEmployee)
        {
            return $"{newEmployee.FirstName} {newEmployee.LastName}";
        }



        public event PropertyChangedEventHandler PropertyChanged;


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
        public BindableCollection<newEmployeeParams> Worker
        {
            get; private set;
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

        /// <summary>
        /// Calculates the age from a birthDateObject
        /// </summary>
        /// <param name="birthDateTime"></param>
        /// <returns></returns>
        private int CalculateAge(DateTime birthDateTime)
        {
            int age = 0;
            
            bool CanShowAge = int.TryParse(
                (DateTime.Now.Year - birthDateTime.Year)
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
