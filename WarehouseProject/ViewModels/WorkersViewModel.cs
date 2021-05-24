using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProject.ViewModels
{
    public class WorkersViewModel
    {

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }


        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Fullname()
        {
            return $"{firstName} {LastName}";
        }
        




    }
}
