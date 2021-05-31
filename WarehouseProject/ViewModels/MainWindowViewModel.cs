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
    public class MainWindowViewModel : BaseViewModel ,IHandle<string>, IHandle<UserLogin>

    {
        private RegisterViewModel register;
        private AccountViewModel account;
        private IEventAggregator ea;

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
                RaisePropertyChanged(this, fullname);
            }
        }


        public RegisterViewModel Register
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
            RegisterViewModel registerView,
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

        public void Handle(UserLogin message)
        {
            Admin user = (Admin)message.newObj;
            fullname = user.Name;
           
        }

        public void Handle(string message)
        {
            Console.WriteLine(message);
        }

       
    }

  
}
