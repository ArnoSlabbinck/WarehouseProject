using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProject.ViewModels
{
    /// <summary>
    /// When the supervisor tries to register new employees 
    /// </summary>
    public class RegistrationViewModel : PropertyChangedBase
    {
        // Bind the data from Password Username
        private DateTime _dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { 
                _dateOfBirth = value;
                NotifyOfPropertyChange(() => DateOfBirth);
            }
        }


        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set { 
                _lastname = value;
                NotifyOfPropertyChange(() => Lastname);
            }
        }


        private int _firstName;

        public int Firstname
        {
            get { return _firstName; }
            set {
                _firstName = value;
                NotifyOfPropertyChange(() => Firstname);
            }
        }



        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set {
                _phone = value;
                NotifyOfPropertyChange(() => Phone);
            }
        }



        private int _salary;

        public int Salary
        {
            get { return  _salary; }
            set {
                _salary = value;
                NotifyOfPropertyChange(() => Salary);
            }
        }



        private string _jobTitle;

        public string JobTitle
        {
            get { return _jobTitle; }
            set { 
                _jobTitle = value;
                NotifyOfPropertyChange(() => JobTitle);
            }
        }



        private string _password;

        public string Password
        {
            get { return _password; }
            set { 
                _password = value;
                NotifyOfPropertyChange(() => Password);

            }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { 
                _username = value;
                NotifyOfPropertyChange(() => Username);

            }
        }




    }
}
