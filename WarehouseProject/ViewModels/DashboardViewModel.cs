using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseProject.EventModels;

namespace WarehouseProject.ViewModels
{
    public class DashboardViewModel : IHandle<UserLoginEvent>
    {
        private IEventAggregator aggregator;
        public DashboardViewModel(IEventAggregator eventAggregator)
        {
            aggregator = eventAggregator;
            aggregator.Subscribe(this);
        }
            
        public void Handle(UserLoginEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
