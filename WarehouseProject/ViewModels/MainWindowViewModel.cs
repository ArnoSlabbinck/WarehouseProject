using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WarehouseProject.Commands;
using WarehouseProject.Data;
using WarehouseProject.EventModels;
using WarehouseProject.Views;

namespace WarehouseProject.ViewModels
{
    public class MainWindowViewModel : BaseViewModel ,IHandle<string>, IHandle<UserLoginEvent>
    {
        private EmployeeViewModel register;
        private AccountViewModel account;
        private IEventAggregator ea;
        private string name;
        private BaseViewModel selectedViewModel;
        public BaseViewModel SelectedViewModel 
        {
            get { return selectedViewModel; }
            set 
            { 
                selectedViewModel = value;
                OnPropertyChanged(nameof(selectedViewModel));
            }
        }


        private string fullname;

        public string Fullname
        {
            get { return fullname; }
            set { 
                fullname = value;
                OnPropertyChanged(nameof(fullname));
            }
        }

        private string function;

        public string Function
        {
            get { return function; }
            set {
                function = value;
                OnPropertyChanged(nameof(Function));
            }
        }

        public EmployeeViewModel Register
        {
            get;
            set;
        }

        public ShutdownCommand Shutdown
        {
            get;
            set;
        }

        public SwitchViewCommand switchView
        {
            get;
            set;
        }

        public MainWindowViewModel(IEventAggregator eventaggretor,
            EmployeeViewModel registerView,
            AccountViewModel accountView)
        {
            ea = eventaggretor;
            register = registerView;
            account = accountView;
            Shutdown = new ShutdownCommand();
            switchView = new SwitchViewCommand(this, register, account);

            //Get the user 
            ea.Subscribe(this);
                
        }

        public void Handle(UserLoginEvent message)
        {
            try
            {
                Admin user = (Admin)message.newObj;
                Fullname = user.Name;
                Function = user.Role;

            } catch (InvalidCastException e)
            {
                User user = (User)message.newObj;
                Fullname = user.Name;
                Function = user.Role;
            }
            
            //I can't asign the. How do I 
           
        }

        public void Handle(string message)
        {
            Console.WriteLine(message);
        }

        public void SetFullname(string name)
        {
            fullname = name;
            
        }
       
    }

  
}
