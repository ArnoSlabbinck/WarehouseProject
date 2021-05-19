
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WarehouseProject.Data
{

    class Admin
    {
        private string paswd;
        public string Name { get; } = "Arno Slabbinck";
        public string Email { get; } = "Arno.Slabbinck@hotmail.com";
        public string Role { get; } = "Admin";
        public string Username
        {
            get
            {
                using (var ctx = new WarehouseDataAccess.WarehouseDBContext())
                {
                    paswd = ctx.Supervisor.First().Username;
                }
                return paswd;
            }
        }

        public string AuthenticationType { get { return "Admin authentication"; } }

        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }
        //

        public string Password
        {
            get
            {
                using (var ctx = new WarehouseDataAccess.WarehouseDBContext())
                {
                    paswd = ctx.Supervisor.First().Password;
                }
                return paswd;
            }
        }
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