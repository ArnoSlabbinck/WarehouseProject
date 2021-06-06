using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseProject.Data;
using WarehouseProject.EventModels;
using WarehouseProject.ViewModels;

namespace WarehouseProject.Commands
{
    public class SwitchViewCommand : ICommand, IHandle<UserLoginEvent>
    {
        private string Fullname;
        private string Role;
        public event EventHandler CanExecuteChanged;
        private MainWindowViewModel main;
        private CustomerViewModel customer;
        private EmployeeViewModel register;
        private AccountViewModel account;
        private DashboardViewModel dashboard;
        private IEventAggregator ea;
        public SwitchViewCommand(IEventAggregator eventaggretor, MainWindowViewModel mainWindow,
            EmployeeViewModel registerView,
            AccountViewModel accountView)
        {
            main = mainWindow;
            register = registerView;
            account = accountView;
            customer = new CustomerViewModel(new CustomerDataService());
            dashboard = new DashboardViewModel(eventaggretor);
            ea = eventaggretor;
            ea.Subscribe(this);
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
                    if (!Role.StartsWith("w"))
                        main.SelectedViewModel = customer;
                    else
                    {
                        main.InvalidAccess = "Invalid access to Customers as a Warehouse worker";
                        main.IsDialogOpen = true;
                    }
                    break;
                case "Employees":
                    if(!Role.StartsWith("w") && !Role.StartsWith("s")) 
                       main.SelectedViewModel = register;
                    else
                    {
                        main.InvalidAccess = "You aren't allowed to add new employees as employee. Contact Admin";
                        main.IsDialogOpen = true;
                    }
                    break;
                case "Dashboard":
                    main.SelectedViewModel = dashboard; 
                    break;
                case "Orders":
                    break;
                case "Account":
                    main.SelectedViewModel = account;
                    break;
                case "Products":
                    if (!Role.StartsWith("s"))
                        Console.WriteLine();
                    else
                    {
                        main.InvalidAccess = "Invalid access to Products as a Salesperson";
                        main.IsDialogOpen = true;
                    }
                    break;
            }
            parameter = null;
        }

        public void Handle(UserLoginEvent message)
        {
            try
            {
                Admin user = (Admin)message.newObj;
                Fullname = user.Name;
                Role = user.Role;

            }
            catch (InvalidCastException e)
            {
                User user = (User)message.newObj;
                Console.WriteLine(user.Role);
                Fullname = user.Name;
                Role = user.Role.Trim().ToLower();

            }

        }
    }
}
