using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels;

namespace WarehouseProject.Data
{
    class LookUpDataService 
    {

        private List<Employee> employees = new List<Employee>();


        public List<Employee> GiveAllEmployees()
        {
            
            
            // Get the data from the DATABASE 
            using (WarehouseDataAccess.WarehouseDBContext ctx = new WarehouseDataAccess.WarehouseDBContext())
            { 
                //Get all the Data out of the database
                foreach(var empl in ctx.Employees)
                {
                    employees.Add(empl);
                }
            }
            return employees;
            
        }

        public object SelectById(int Id)
        {
            throw new NotImplementedException();
        }

        public object SelectByName(string fullname)
        {
            throw new NotImplementedException();
        }
    }
}
