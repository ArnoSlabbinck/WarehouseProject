using System.ComponentModel;

namespace WarehouseProject.Data
{
    public interface IDataValidation : INotifyDataErrorInfo
    {
        //
        string CheckRegistration(string data, AuthenticationService authentication);

    }
}