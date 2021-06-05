using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseProject.ViewModels;

namespace WarehouseProject.Commands
{
    public class ContactCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ContactViewModel contactView;

        public ContactCommand(ContactViewModel error)
        {
            contactView = error;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Need to display the error view withouth opening a new Window
            // Use an
        }
    }
}
