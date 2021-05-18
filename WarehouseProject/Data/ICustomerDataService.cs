using System.Collections.Generic;
using WarehouseModels;

namespace WarehouseProject.Data
{
    public interface ICustomerDataService
    {
        IEnumerable<Customers> GetAllCustomers();
    }
}