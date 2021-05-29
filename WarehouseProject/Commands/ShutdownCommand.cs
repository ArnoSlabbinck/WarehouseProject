using Caliburn.Micro;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WarehouseProject.Views;

namespace WarehouseProject.Commands
{
    public class ShutdownCommand: ICommand
    {
        private DialogClosingEventHandler closingEventHandler;

        public event EventHandler CanExecuteChanged;

        

        public ShutdownCommand( )
        {

        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            
            var window = parameter as MainWindowView;
            window.Close();
        }
    }
}
