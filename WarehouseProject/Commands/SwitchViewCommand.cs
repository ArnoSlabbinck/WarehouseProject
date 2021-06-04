using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseProject.Data;
using WarehouseProject.ViewModels;

namespace WarehouseProject.Commands
{
    public class SwitchViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MainWindowViewModel main;
        private CustomerViewModel customer;
        private EmployeeViewModel register;
        private AccountViewModel account;
        public SwitchViewCommand(MainWindowViewModel mainWindow,EmployeeViewModel registerView, AccountViewModel accountView)
        {
            main = mainWindow;
            register = registerView;
            account = accountView;
            customer = new CustomerViewModel(new CustomerDataService());
        }
        public bool CanExecute(object parameter)
        {
            return true; 
        }

        public void Execute(object parameter)
        {
            
            var stringView = parameter as string;
            switch (stringView)
            {
                case "Customers":
                    main.SelectedViewModel = customer;
                    break;
                case "Employees":
                    main.SelectedViewModel = register;
                    break;
                case "Dashboard":
                    break;
                case "Orders":
                    break;
                case "Account":
                    main.SelectedViewModel = account;
                    break;
                case "Products":
                    break;
            }
            parameter = null;
        }
    }
}
