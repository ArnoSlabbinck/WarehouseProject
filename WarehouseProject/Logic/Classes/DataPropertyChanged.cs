using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProject.Data
{
    public abstract class DataPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(object sender, string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
