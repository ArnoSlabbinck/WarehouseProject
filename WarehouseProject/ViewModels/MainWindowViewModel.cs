using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WarehouseProject.Commands;
using WarehouseProject.Data;
using WarehouseProject.EventModels;
using WarehouseProject.Views;

namespace WarehouseProject.ViewModels
{
    public class MainWindowViewModel : DataPropertyChanged ,IHandle<string>, IHandle<MyMessageEventcs>

    {
        private RegisterViewModel register;
        private IEventAggregator ea;

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

        public MainWindowViewModel(IEventAggregator eventaggretor)
        {
            ea = eventaggretor;
            Shutdown = new ShutdownCommand();
            //Get the user 
            ea.Subscribe(this);
        
        }

        public void Handle(MyMessageEventcs message)
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
