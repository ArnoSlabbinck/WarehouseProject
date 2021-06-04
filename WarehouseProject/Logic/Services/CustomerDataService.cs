using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels;

namespace WarehouseProject.Data
{
    public class CustomerDataService : ICustomerDataService
    {
        public async  Task<bool> Add(string[] customerParas)
        {
            Customers customers = new Customers();
            using (var context = new WarehouseDataAccess.WarehouseDBContext())
            {
                //Check if there are no duplicates
                var fullname = context.Customers.FirstOrDefault(c => c.Fullname == customerParas[0]);
                if (fullname == null)
                {
                    string[] name = customerParas[0].Trim().Split(' ');
                    customers.FirstName = name[0];
                    customers.LastName = name[1];
                    customers.Email = customerParas[1];
                    customers.Phone = customerParas[2];
                    customers.Country = customerParas[3];
                    customers.City = customerParas[4];
                    customers.Street = customerParas[5];
                    context.Customers.Add(customers);
                    await context.SaveChangesAsync();
                    Console.WriteLine("Save Complete");
                    return true;
                }
                else
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
    }

   
}
