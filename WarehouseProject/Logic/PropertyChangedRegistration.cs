using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProject.Data
{
    public abstract class PropertyChanged : PropertyChangedBase, IPropertyChangedRegistration
    {
        private DateTime _dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                NotifyOfPropertyChange(() => DateOfBirth);
            }
        }


        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                NotifyOfPropertyChange(() => Lastname);
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }


        private int _firstName;

        public int Firstname
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => Firstname);
            }
        }

        public ObservableCollection<string> WorkTypes { get; private set; }


        private string _mobile;

        public string Mobile
        {
            get { return _mobile; }
            set
            {
                _mobile = value;
                NotifyOfPropertyChange(() => Mobile);
            }
        }



        private int _salary;

        public ObservableCollection<int> Salaries { get; private set; }



        private string _jobTitle;

        public string JobTitle
        {
            get { return _jobTitle; }
            set
            {
                _jobTitle = value;
                NotifyOfPropertyChange(() => JobTitle);
            }
        }



        private string _password;
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*?&])([a-zA-Z0-9@$!%*?&]{8,})$",
            ErrorMessage = "Password has next Requirements:" +
            "At least 8 characters long," +
            "One lowercase, one uppercase, one number and one special character" +
            " No whitespaces")]
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);

            }
        }
    }
}
