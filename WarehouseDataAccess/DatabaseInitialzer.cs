using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseDataAccess
{
    internal class DatabaseInitialzer : DropCreateDatabaseIfModelChanges<WarehouseDBContext>
    {
        seed
    }
}
