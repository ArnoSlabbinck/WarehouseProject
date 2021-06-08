using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseProject.ViewModels;

namespace WarehouseProject.Commands
{
    public class EditCustomerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private CustomerViewModel CustomerView;

        public EditCustomerCommand(CustomerViewModel customerViewModel)
        {
            CustomerView = customerViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CustomerView.ShowEditDialog();
        }
    }
}
