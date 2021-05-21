
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WarehouseModels;

namespace WarehouseProject.Data
{

    class Admin
    {
        private Supervisor supervisor;
        public Admin() 
        {
            using (var ctx = new WarehouseDataAccess.WarehouseDBContext())
            {
                supervisor = ctx.Supervisor.First();
                Password = supervisor.Password;
                Name = supervisor.ToString();
                Username = supervisor.Username;
                Email = "Arno.Slabbinck@hotmail.com";
                Role = "Admin";
            }
        
        }

        public string Name { get; private set; } 
        public string Email { get; private set; } = "Arno.Slabbinck@hotmail.com";
        public string Role { get; private set; } = "Admin";
        public string Username { get; private set; }

        public string AuthenticationType { get { return "Admin authentication"; } }

        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }
        //

        public string Password { get; private set; }

        
        public string CalculateHashPassword(string textPassword)
        {
            //Conver the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(textPassword);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            string password = Convert.ToBase64String(algorithm.ComputeHash(saltedHashBytes));

            return password;

        }

    }
}