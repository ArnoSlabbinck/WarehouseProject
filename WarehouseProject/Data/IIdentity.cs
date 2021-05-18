using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProject.Data
{
    interface IIdentity
    {
        string Name { get; set; }
        string Email { get; set; }
        string Role { get; set; }

        string Username { get; set; }

    }
}
