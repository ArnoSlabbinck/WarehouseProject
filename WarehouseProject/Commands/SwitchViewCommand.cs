using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseProject.ViewModels;

namespace WarehouseProject.Commands
{
    public class SwitchViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MainWindowViewModel main;
        private EmployeeViewModel register;
        private AccountViewModel account;
        public SwitchViewCommand(MainWindowViewModel mainWindow,EmployeeViewModel registerView, AccountViewModel accountView)
        {
            main = mainWindow;
            register = registerView;
            account = accountView;
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
                case "Customer":
                    Console.WriteLine("Customer");
                    break;
                case "Employees":
                    main.SelectedViewModel = register;
                    break;
                case "Dashboard":
                    Console.WriteLine("Dashboard");
                    break;
                case "Orders":
                    Console.WriteLine("Orders");
                    break;
                case "Account":
                    Console.WriteLine("Account");
                    main.SelectedViewModel = account;
                    break;
            }
            parameter = null;
        }
    }
}
