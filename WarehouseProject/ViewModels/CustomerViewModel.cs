﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels;
using System.Collections.ObjectModel;
using WarehouseProject.Data;
using System.ComponentModel;
using Caliburn.Micro;
using WarehouseProject.Commands;
using System.Windows;

namespace WarehouseProject.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        private string[] customerParams;

        private string errors;

        public string  Errors
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
            set {
                _IsDialogOpen = value;
                OnPropertyChanged(nameof(IsDialogOpen));
                    
                }
        }


        private string fullname;

        public string Fullname
        {
            get { return fullname; }
            set 
            {
                fullname = value;
                OnPropertyChanged(nameof(Fullname));
            }
        }


        private string email;

        public string Email
        {
            get { return email; }
            set 
            { 
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }


        private string phone;

        public string Phone
        {
            get { return phone; }
            set 
            { 
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }


        private string street;

        public string Street
        {
            get { return street; }
            set 
            { 
                street = value;
                OnPropertyChanged(nameof(Street));
            }
        }


        private string city;

        public string City
        {
            get { return city; }
            set 
            { 
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set {
                country = value;
                OnPropertyChanged(nameof(Country));
            }
        }


        public AddCustomerCommand addCustomerCommand { get; set; }
        public  CustomerConverter CustomerConverter { get; set; }

        private ICustomerDataService _customerDataService;
        // When you want to add or remove customers this will notify that change from the databinding
        private Customers _selectedCustomer;
        
        public CustomerViewModel(ICustomerDataService CustomerDataService)
        {
            
            _customerDataService = CustomerDataService;
            Customers = new BindableCollection<Customers>();
            addCustomerCommand = new AddCustomerCommand(this);
            CustomerConverter = new CustomerConverter();
            Load();

        }
        /// <summary>
        /// Load all the customers from database
        /// </summary>
        public async void Load()
        {
            List<Customers> customers = (List<Customers>)await Task.Run(() => _customerDataService.GetAllCustomers());
            Customers.Clear();//No duplicates if load method is called 
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName);       
                Customers.Add(customer);
            }
        }

        public  void Add()
        {
            customerParams = new string[10];
            customerParams[0] = Fullname;
            customerParams[1] = Email;
            customerParams[2] = Phone;
            customerParams[3] = Country;
            customerParams[4] = City;
            customerParams[5] = Street;

            Task<bool> succesAddedCustomer =  _customerDataService.Add(customerParams);
            
            if (Task.Equals(succesAddedCustomer, true))
            {
                Errors = "Customer has been added";
            }
            else {
                Errors = "Something went wrong.Check if you have entered everything right";
            }
        }

        /// <summary>
        /// Adds the Inputs from customerview to database
        /// </summary>
        public async void Update()
        { 
        
        }
        /// <summary>
        /// Deletes the Customer from a database
        /// </summary>
        public async void Delete()
        { 
        
        }
        public BindableCollection<Customers> Customers { get; set; }

        //if user selects a customer => Display customer data  
        public Customers SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value; }
        }

        public void OnShowDialog()
        {
            Console.WriteLine("h");
            
            IsDialogOpen = true;
        }

    }
}
