﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseProject.ViewModels;

namespace WarehouseProject.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ProductViewModel productViewModel;

        public DeleteProductCommand(ProductViewModel productView)
        {
            productViewModel = productView;
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
