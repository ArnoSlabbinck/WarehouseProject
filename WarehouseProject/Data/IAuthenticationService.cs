using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProject.Data
{
    interface IAuthenticationService
    {
        User Login(string username, string password);
        //You get the username and password and create the Current User
        List<string> Register(newEmployeeParams newEmployee);
    }
}
