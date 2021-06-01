using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseProject.Data;
using WarehouseProject.EventModels;

namespace WarehouseProject.ViewModels
{
    public class AccountViewModel : BaseViewModel, IHandle<UserLoginEvent>
    {
        private IEventAggregator events;

        private string fullname;

        public string Fullname
        {
            get { return fullname; }
            set {
                fullname = value;
                OnPropertyChanged(nameof(fullname)); 
            }
        }


        private string email ;

        public string Email
        {
            get { return email; }
            set { 
                email = value;
                OnPropertyChanged(nameof(email));

            }
        }

        private string role;

        public string Role
        {
            get { return role; }
            set 
            { 
                role = value;
                OnPropertyChanged(nameof(role));

            }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set 
            { 
                country = value;
                OnPropertyChanged(nameof(country));

            }

        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set 
            {
                gender = value;
                OnPropertyChanged(nameof(gender));
            }
        }


        private string status;

        public string Status
        {
            get { return status; }
            set 
            {
                status = value;
                OnPropertyChanged(nameof(status));
            }
        }


        public AccountViewModel(IEventAggregator eventAggregator)
        {
            events = eventAggregator;
            events.Subscribe(this);

        }

        public void Handle(UserLoginEvent message)
        {
            try
            {
                Admin user = (Admin)message.newObj;
                Fullname = user.Name;
                Email = user.Email;
                Role = user.Role;
                Username = user.Username;
                Country = "Belgium";
                Gender = "Male";
                Status = user.IsAuthenticated.ToString();


            }
            catch (InvalidCastException e)
            {
                User user = (User)message.newObj;
                Fullname = user.Name;
                Email = user.Email;
                Role = user.Role;
                Username = user.Username;
                Country = "Belgium";
                Gender = "Male";
                Status = user.IsAuthenticated.ToString();

            }


        }


        
    }
}
