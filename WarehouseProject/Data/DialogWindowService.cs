using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WarehouseProject.Data
{
    public class DialogWindowService<T> : IDialogWindowService<T> where T : Window
    {
        private readonly SimpleContainer container = new SimpleContainer();
        public void Show()
        {
            throw new NotImplementedException();
        }

        public void ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}
