using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
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

        private int age;

        public int Age
        {
            get { return age; }
            set 
            {
                age = value;
                OnPropertyChanged(nameof(age));
            }
        }

        private BitmapImage image;

        public BitmapImage Image
        {
            get { return image; }
            set 
            { 
                image = value;
                OnPropertyChanged(nameof(image));
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
                var name = user.Name.Split(' ')[0];
                Email = user.Email;
                Role = user.Role;
                Username = user.Username;
                Country = "Belgium";
                Gender = "Male";
                Age = 26;
                Status = user.IsAuthenticated.ToString();
                FindImage(name);


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

        public void FindImage(string name)
        {
            Uri resourceUri = new Uri(FindRelativePathImage(name), UriKind.Absolute);
            Image = new BitmapImage(resourceUri);
        }

        /// <summary>
        /// Find the relative path from current directory to target directory file path
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string  FindRelativePathImage(string name)
        {
            string directory1 = string.Empty;
            DirectoryInfo[] directories = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.GetDirectories();

            foreach (var directory in directories)
            {
                if(directory.FullName.Contains("Images") == true)
                {
                    foreach (var dirs in directory.GetDirectories())
                    {
                        if (dirs.FullName.Contains("Employees") == true)
                        {
                            directory1 = dirs.FullName;                        
                        }
                    }

                }
                
            }


            var files = Directory.GetFiles(directory1, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                if (Path.GetFileNameWithoutExtension(file) == name)
                {
                    return Path.GetFullPath(file);

                }
            }
            return null;

        }
    }
}
