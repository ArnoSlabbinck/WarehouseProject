using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WarehouseProject.ViewModels;

namespace WarehouseProject.Commands
{
    public class AddCustomerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private CustomerViewModel customerViewModel;
        public AddCustomerCommand(CustomerViewModel customerView)
        {
            customerViewModel = customerView;
        
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        /// <summary>
        /// Displays a message to the user when the customer has been added. 
        /// When an error occurs it will give the appropricate message
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            string[] customerData = new string[]
            { "Fullname","Email" ,
            "Country","City",
            "Street","Phone" };
            var customerValues = (object[])parameter;
            string[] errorMessages = new string[10];
            int counter = 0;
            for (int i = 0; i < customerValues.Length; i++)
            {
                
                if (string.IsNullOrEmpty((string)customerValues[i]))
                {
                    
                    errorMessages[counter] = $"{customerData[counter]} can not be empty";
                    counter++;
                }
            }

            if (errorMessages[0] == null)
            {
                customerViewModel.Add();
                customerViewModel.OnShowDialog();
                ResetCustomerFields();
            }
            else
            {
               
                string errors = string.Empty;
                foreach (var par in errorMessages)
                {
                    errors += par + "\n";
                }
                customerViewModel.Errors = errors;
                customerViewModel.OnShowDialog();
                ResetCustomerFields();
            }
        }

        /// <summary>
        /// Makes every field to add a new customer back to null
        /// </summary>
        private void ResetCustomerFields()
        {
            customerViewModel.City = null;
            customerViewModel.Country = null;
            customerViewModel.Email = null;
            customerViewModel.Fullname = null;
            customerViewModel.Street = null;
            customerViewModel.Phone = null;
        
        
        }



        
    }
    public class CustomerConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
