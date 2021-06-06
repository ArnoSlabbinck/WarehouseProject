using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseProject.Data;
using WarehouseProject.EventModels;

namespace WarehouseProject.ViewModels
{
    public class DashboardViewModel : BaseViewModel, IHandle<UserLoginEvent>
    {
        private string Fullname;

        private string welcome;

        public string Welcome
        {
            get { return welcome; }
            set 
            { 
                welcome = value;
                OnPropertyChanged(nameof(Welcome));
            }
        }


        private IEventAggregator aggregator;
        public DashboardViewModel(IEventAggregator eventAggregator)
        {
            aggregator = eventAggregator;
            aggregator.Subscribe(this);
        }
            
        public void Handle(UserLoginEvent message)
        {
            try
            {
                Admin user = (Admin)message.newObj;
                Fullname = user.Name;
                int index = Fullname.IndexOf(' ');
                Welcome = $"Welcome, {Fullname.Substring(0, index)}!";

            }
            catch (InvalidCastException e)
            {
                User user = (User)message.newObj;
                Fullname = user.Name;


            }
        }
    }
}
