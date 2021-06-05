using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseProject.ViewModels;

namespace WarehouseProject.Commands
{
    public class DeleteCustomerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private CustomerViewModel CustomerView;
        public DeleteCustomerCommand(CustomerViewModel customerViewModel)
        {
            CustomerView = customerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        /// <summary>
        /// Calls the CustomerViewModel Delete method to Delete the selectedCustomer
        /// from the CustomerView 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            // get the Id Use that to find the customer in the database 
            int id = (int)parameter;
            Console.WriteLine(id);

        }
    }
}
