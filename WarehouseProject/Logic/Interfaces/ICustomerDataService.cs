using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseModels;

namespace WarehouseProject.Data
{
    public interface ICustomerDataService
    {
        IEnumerable<Customers> GetAllCustomers();

        IEnumerable<Customers> GetCustomersByName();

        IEnumerable<Customers> GetCustomersByCity();

        IEnumerable<Customers> GetCustomersByCountry();

        Task<bool> Add(string[] customerParas);

        void Delete();
        void Update();
    }

    
}