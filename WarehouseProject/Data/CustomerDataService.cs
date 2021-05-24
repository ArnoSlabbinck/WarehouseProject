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
        public IEnumerable<Customers> GetAllCustomers()
        {
            //TODO:Load all customers from Database
            yield return new Customers { FirstName = "Arno", LastName = "Slabbinck", Email = "arno.slabbinck@hotmail.com" };
            yield return new Customers { FirstName = "Julie", LastName = "Slabbinck", Email = "julie.slabbinck@hotmail.com" };
            yield return new Customers { FirstName = "Mario", LastName = "Slabbinck", Email = "mario.slabbinck@hotmail.com" };
            

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


    }
}
