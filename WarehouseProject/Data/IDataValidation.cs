using System.Collections.Generic;
using System.ComponentModel;

namespace WarehouseProject.Data
{
    public interface IDataValidation : INotifyDataErrorInfo
    {
        //
        List<string> CheckRegistration(string data, AuthenticationService authentication);

    }
}