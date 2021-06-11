using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels;
using WarehouseProject.Logic.Classes;

namespace WarehouseProject.Logic.Interfaces
{
    public class ProductDataService : IDataSerivce
    {
        public Task<bool> Add(object obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(object obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(object obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Products> CategoryWithProducts()
        {
            List<Products> customers = new List<Products>();
            using (var context = new WarehouseDataAccess.WarehouseDBContext())
            {
                foreach (var customer in context.Products)
                {
                    customers.Add(customer);
                }

                return customers;
            }



        }
    }
}
