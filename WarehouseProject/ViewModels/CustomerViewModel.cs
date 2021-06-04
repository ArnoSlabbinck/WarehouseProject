using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels;
using System.Collections.ObjectModel;
using WarehouseProject.Data;
using System.ComponentModel;
using Caliburn.Micro;

namespace WarehouseProject.ViewModels
{
    class CustomerViewModel : BaseViewModel
    {
        private ICustomerDataService _customerDataService;
        // When you want to add or remove customers this will notify that change from the databinding
        private Customers _selectedCustomer;
        
        public CustomerViewModel(ICustomerDataService CustomerDataService)
        {
            Customers = new BindableCollection<Customers>();
            _customerDataService = CustomerDataService;
            Load();
        
        }
        /// <summary>
        /// Load all the customers from database
        /// </summary>
        public void Load()
        {
            var customers = _customerDataService.GetAllCustomers();
            Customers.Clear();//No duplicates if load method is called twice
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }
        public BindableCollection<Customers> Customers { get; set; }

        //if user selects a customer => Display customer data  
        public Customers SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value; }
        }

        
    }
}
