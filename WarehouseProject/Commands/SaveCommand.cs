﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseProject.ViewModels;

namespace WarehouseProject.Commands
{
    public class SaveCommand : ICommand
    {
        RegistrationViewModel registration;
        public event EventHandler CanExecuteChanged;
        public SaveCommand(RegistrationViewModel _registration)
        {
            registration = _registration;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            registration.Validation();
        }
    }
}
