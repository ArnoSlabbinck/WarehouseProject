using System.Collections.Generic;

namespace WarehouseProject.Data
{
    internal interface ILookupDataService
    {
        List<object> GiveAllData(object obj);

        object SelectByName(string fullname);

        object SelectById(int Id);


        
        
    }
}