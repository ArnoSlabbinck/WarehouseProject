using System;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Security.Cryptography;
using System.Text;

namespace WarehouseDataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WarehouseDataAccess.WarehouseDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WarehouseDBContext context)
        {
            try
            {
                // Add one supervisor
                context.Supervisor.Add(
                    new WarehouseModels.Supervisor
                    {
                        FirstName = "Arno",
                        LastName = "Slabbinck",
                        Username = "Arno94",
                        Password = CalculateHashPassword(), 
                        Workers =
                        {
                        new WarehouseModels.Employee()
                        {
                            FirstName = "Philip",
                            LastName = "Hastings",
                            Email = "Philip.Hastings@hotmail.com",
                            JobTitle ="Warehouse Worker",
                            Salary = 45000,
                            Gender = "Male",
                            IsActive = true,
                            FailedPasswordAttemptCount = 0,
                            PassWord = CalculateHashPassword(),
                            UserName = "Mark",
                             
                        },

                        new WarehouseModels.Employee()
                        {
                            FirstName = "Mary",
                            LastName = "Lambeth",
                            Gender = "Female",
                            Salary = 3000,
                            JobTitle = "SalesPerson",
                            UserName = "Mary",
                            PassWord = CalculateHashPassword(),
                            Email = "Mary.Lambeth@hotmail.com",
                            IsActive = true,
                            FailedPasswordAttemptCount = 0,

                        }


                        }
                    });

                context.SaveChanges();


            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }


        }

        public string CalculateHashPassword()
        {
            string textPassword = "Ypsp2man!";
            //Conver the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(textPassword);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            string password = Convert.ToBase64String(algorithm.ComputeHash(saltedHashBytes));

            return password;


        }
    }
}
