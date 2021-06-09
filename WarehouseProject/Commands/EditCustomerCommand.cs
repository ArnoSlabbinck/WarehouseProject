using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseModels;
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
             

            if ((string)parameter == "NewCustomer")
            {
                string firstnameSelectedCustomer = string.Empty;
                string lastnameSelectedCustomer = string.Empty;

                string[] customerData = new string[]
                 { "FirstName", "LastName", "Email" ,
                "Phone","Country",
                 "City","Street" };
                int index = 0;

                string[] name = CustomerView.SelectedCustomer.Fullname.Split(' ');
                var FirstnameSelectedCustomer = name[0];
                var LastnameSelectedCustomer = name[1];

                //Takes the fullname and splits it into firstname and lastname to match with entity
                if (!string.IsNullOrEmpty(CustomerView.Fullname))
                {
                    string[] name2 = CustomerView.Fullname.Split(' ');
                    firstnameSelectedCustomer = name2[0];
                    lastnameSelectedCustomer = name2[1];

                }

                Dictionary<string, string> CompareNewVsOldCustomersData = new Dictionary<string, string>();
                CompareNewVsOldCustomersData.Add(FirstnameSelectedCustomer, firstnameSelectedCustomer);
                CompareNewVsOldCustomersData.Add(LastnameSelectedCustomer, lastnameSelectedCustomer);
                CompareNewVsOldCustomersData.Add(CustomerView.SelectedCustomer.Email, CustomerView.Email);
                CompareNewVsOldCustomersData.Add(CustomerView.SelectedCustomer.Phone, CustomerView.Phone);
                CompareNewVsOldCustomersData.Add(CustomerView.SelectedCustomer.Country, CustomerView.Country);
                CompareNewVsOldCustomersData.Add(CustomerView.SelectedCustomer.City, CustomerView.City);
                CompareNewVsOldCustomersData.Add(CustomerView.SelectedCustomer.Street, CustomerView.Street);
                foreach(var data in CompareNewVsOldCustomersData)
                {
                    if (!string.IsNullOrEmpty(data.Value) && !data.Key.Contains(data.Value))
                    {
                        //Use properties from selected customer to compare the 
                        SetValueSelectedCustomer(customerData[index], data.Value); 
                        
                    }
                    index++;
                }


                CustomerView.Update();
                CustomerView.OnShowDialog();

            }
            else
            {
                CustomerView.ShowEditDialog();
            }

        }

        /// <summary>
        /// Sets a new value for the given property in my selectedCustomer
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="newCustomerValue"></param>
        private void SetValueSelectedCustomer(string methodName, string newCustomerValue)
        {

            PropertyInfo prop = CustomerView.SelectedCustomer.GetType().GetProperty(methodName, BindingFlags.Public | BindingFlags.Instance);
            
            if (null != prop && prop.CanWrite)
            {
                Console.WriteLine(prop.Name);
                prop.SetValue(CustomerView.SelectedCustomer, newCustomerValue, null);

            }

            
        }



    }
}
