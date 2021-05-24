using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WarehouseProject.ViewModels;

namespace WarehouseProject.Commands
{
    public class ShowEmployeesCommand : ICommand
    {
        readonly RegistrationViewModel registrationView;

        public ShowEmployeesCommand(RegistrationViewModel registration)
        {
            registrationView = registration;
            // Als er een event is => Geclickt op 
            
        }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            
            return true;
        }

        public void Execute(object parameter)
        {
            registrationView.ShowAllEmployees();
        }
    }
}
