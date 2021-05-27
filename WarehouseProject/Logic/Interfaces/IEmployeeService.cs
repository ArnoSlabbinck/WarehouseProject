using System.Collections.Generic;
using WarehouseModels;

namespace WarehouseProject.Data
{
    internal interface ILookupDataService
    {
        List<Employee> GiveAllEmployees(object obj);

        object SelectByName(string fullname);

        object SelectById(int Id);


        
        
    }
}