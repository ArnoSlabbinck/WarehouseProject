using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels;

namespace WarehouseProject.Data
{
    public class CustomerDataService : ICustomerDataService
    {
        /// <summary>
        /// Add a new customer asynchronously and check for errors. Display those errors
        /// To the user
        /// </summary>
        /// <param name="customerParas"></param>
        /// <returns></returns>
        public async  Task<bool> Add(string[] customerParas)
        {
            Customers customers = new Customers();
           
            try 
            {
                using (var context = new WarehouseDataAccess.WarehouseDBContext())
                {
                    string[] name = customerParas[0].Trim().Split(' ');
                    var firstname = NameWithACapitalLetter(name[0]);
                    var lastname = NameWithACapitalLetter(name[1]);
                    //Check if there are no duplicates
                    var CustomerExist = context.Customers.FirstOrDefault(p => p.FirstName == firstname && p.LastName == lastname);

                    if (CustomerExist == null)
                    {

                        
                        customers.FirstName = firstname;
                        customers.LastName = lastname;
                        customers.Email = customerParas[1];
                        customers.Phone = customerParas[2];
                        customers.Country = customerParas[3];
                        customers.City = customerParas[4];
                        customers.Street = customerParas[5];
                        customers.Number = "0";
                        context.Customers.Add(customers);
                        await context.SaveChangesAsync();
                        Console.WriteLine("Save Complete");
                        return true;
                    }
                    return false;
                }

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        
                    }
                }
                return false;
            }
            
                
        }
    

        public async Task<bool> Delete(Customers Customer)
        {
            try
            {
                using (var context = new WarehouseDataAccess.WarehouseDBContext())
                {
                    Customers DeleteCustomer = context.Customers.Find(Customer.Id);
                    context.Customers.Remove(DeleteCustomer);
                    //Update the Id's in the database 
                    await context.SaveChangesAsync();
                    return true;

                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.InnerException} => {e.Message}: {e.Data}");
                return false;
            }
            
            
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            List<Customers> customers = new List<Customers>();
            using(var context = new WarehouseDataAccess.WarehouseDBContext())
            {
                foreach (var customer in context.Customers)
                {
                    customers.Add(customer);
                }

                return customers;
            }

        }

       

        public async Task<bool> Update(Customers customer)
        {
            try
            {
                // We only need to update the parts of the customer 
                // that are different from the customer in the database
                // Get the Customer from the database 
                using(var context = new WarehouseDataAccess.WarehouseDBContext())
                {
                    Customers customerDatabase = context.Customers.Find(customer.Id);
                    if (customerDatabase == null)
                        return false;
                    context.Entry(customerDatabase).CurrentValues.SetValues(customer);
                    await context.SaveChangesAsync();
                    return true;

                }

                
            }
            catch(Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Set the first letter of the string to a capital letter
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string NameWithACapitalLetter(string name)
        {
            return name.Substring(0,1).ToUpper()
                        + name.Substring(1, name.Length - 1).ToLower();
        }

        private string[] CustomerData(Customers customers)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Resets every customers id back to right id after deleted a customer
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        public IEnumerable<Customers> GetCustomersByCity()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customers> GetCustomersByCountry()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customers> GetCustomersByName()
        {
            throw new NotImplementedException();
        }


    }



   
}
