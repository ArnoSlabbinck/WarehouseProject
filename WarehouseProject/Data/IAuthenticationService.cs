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

        bool Register(string FirstName, string LastName, string Username, string Password, string Email, string Role);
    }
}
