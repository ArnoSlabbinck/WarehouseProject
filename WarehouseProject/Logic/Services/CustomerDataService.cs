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
    

        public void Delete()
        {
            throw new NotImplementedException();
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

        public void Update()
        {
            throw new NotImplementedException();
        }

        private string NameWithACapitalLetter(string name)
        {
            return name.Substring(0,1).ToUpper()
                        + name.Substring(1, name.Length - 1).ToLower();
        }
    }

   
}
