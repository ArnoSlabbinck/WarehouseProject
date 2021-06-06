using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using WarehouseProject.Commands;
using WarehouseProject.Data;
using WarehouseProject.EventModels;
using WarehouseProject.Logic.Classes;
using WarehouseProject.Logic.Interfaces;
using WarehouseProject.Views;


namespace WarehouseProject.ViewModels
{
    public class MainWindowViewModel : BaseViewModel ,
        IHandle<UserLoginEvent>
    {
        private EmployeeViewModel register;
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

        private string invalidAccess;

        public string InvalidAccess
        {
            get { return invalidAccess; }
            set {
                invalidAccess = value;
                OnPropertyChanged(nameof(InvalidAccess));
            }
        }


        private bool _IsDialogOpen;
        public bool IsDialogOpen
        {
            get { return _IsDialogOpen; }
            set
            {
                _IsDialogOpen = value;
                OnPropertyChanged(nameof(IsDialogOpen));

            }
        }

        private TimeSpan today;

        public TimeSpan Today
        {
            get { return today; }
            set 
            { 
                today = value;
                OnPropertyChanged(nameof(Today));
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

       

        public  MainWindowViewModel(IEventAggregator eventaggretor,
            EmployeeViewModel registerView,
            AccountViewModel accountView)
        {
            ea = eventaggretor;
            register = registerView;
            account = accountView;
            Shutdown = new ShutdownCommand();
            switchView = new SwitchViewCommand(eventaggretor,this, register, account);
            selectedViewModel = new DashboardViewModel(ea);
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

        public void SetFullname(string name)
        {
            fullname = name;
                
        }

        /// <summary>
        /// Set up a Timer to display the date and 
        /// </summary>
        public async Task setTimer()
        {
            // Get the date and the time of 
            // Use a while loop to continue ticking
            await System.Windows.Application.
                Current.Dispatcher.BeginInvoke(new System.Action(() =>
                {
                    DateTime dateTime = DateTime.Now;
                    var time = dateTime.TimeOfDay;

                    Today = time;
                    Thread.Sleep(TimeSpan.FromSeconds(60));



                }));



        }
        public void OnShowDialog()
        {


            IsDialogOpen = true;
        }


    }

  
}
