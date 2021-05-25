using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels;
using System.Security.Cryptography;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Data.Entity.Validation;

namespace WarehouseProject.Data
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly User ErrorUser = new User();
        readonly List<string> Errors = new List<string>();
        private string lastName = string.Empty;
        private string email = string.Empty;
        private string firstName = string.Empty;
        private string password = string.Empty;


        /// <summary>
        /// Check User for psw and username
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Login(string username, string password)
        {

            string usernameInDb;
            using (var ctx = new WarehouseDataAccess.WarehouseDBContext())
            {
                ctx.Database.Log = (message) => Debug.WriteLine(message);
                Employee employee = ctx.Employees.Where(p => p.UserName == username).FirstOrDefault();
                if (employee == null)
                {
                    ErrorUser.InvalidLogin = false;
                    return ErrorUser;
                }
                else
                {
                    usernameInDb = employee.UserName;

                    if (usernameInDb != null)
                    {
                        //Check the  password
                        string Salt = employee.PassWordSalt;
                        string pswd = CalculateHashPassword(Salt, password);

                        if (pswd == employee.PassWord)
                        {
                            //Create a User from Employee

                            User user = new User();
                            user.Email = employee.Email;
                            user.Name = employee.FullName();
                            user.Password = employee.PassWord;
                            user.Role = employee.JobTitle;
                            user.Username = employee.UserName;
                            user.IsAuthenticated = true;
                            return user;
                        }

                        else
                        {
                            // Should raise error  => capture that error and display that message to User

                            ErrorUser.InvalidLogin = false;
                            // Find the Username => then 
                            if (employee.FailedPasswordAttemptCount == 3)
                            {
                                employee.IsLockedOut = true;
                                ErrorUser.IsAuthenticated = false;
                                return ErrorUser;
                            }
                            employee.FailedPasswordAttemptCount++;
                            ErrorUser.IsAuthenticated = false;
                            return ErrorUser;
                        }
                    }

                }

            }
            ErrorUser.IsAuthenticated = false;

            return ErrorUser;

        }

        /// <summary>
        /// Need to  get the password
        /// Need the username
        /// No duplicates => First Check if user not in database
        /// Password hashing sha256 
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        public List<string> Register(newEmployeeParams newEmployee)
        {
            
            
            //Check first of the user doesn't exist already
            bool userExist = false;
            try
            {
                using (var context = new WarehouseDataAccess.WarehouseDBContext())
                {
                    // if empty than false 
                    userExist = context.Employees.FirstOrDefault(p => p.FirstName == newEmployee.FirstName
                    && p.LastName == newEmployee.LastName) != null ? true : false;

                    if (userExist == false)
                    {
                        //Generate an 128-bit random number salt to make crypto collitions unlikely
                        //First hash password
                        var supervisor = context.Supervisor.First();
                        string Salt = GenerateSalt();
                        password = CalculateHashPassword(newEmployee.Password, Salt);
                        Console.WriteLine($"{newEmployee.FirstName} {newEmployee.Gender} {newEmployee.Salaries} {newEmployee.Password}");
                        Employee Employee = new Employee
                        {
                            FirstName = newEmployee.FirstName,
                            LastName = newEmployee.LastName,
                            Email = newEmployee.Email,
                            PassWord = password,
                            PassWordSalt = Salt,
                            JobTitle = newEmployee.JobTitle,
                            FailedPasswordAttemptCount = 0,
                            IsActive = true,
                            UserName = newEmployee.Username,
                            Salary = newEmployee.Salaries,
                            Gender = newEmployee.Gender,
                            BirthDate = newEmployee.BirthDate,
                            Supervisor = supervisor
                        };
                        context.Employees.Add(Employee);
                        context.SaveChanges();
                    }

                    else
                    {
                        Errors.Add($"{newEmployee.FirstName} {newEmployee.LastName} is already in the database");
                        // Raise an Error when the User 
                        return Errors;

                    }
                    

                }

                return Errors;

                //Check firstName and Lastname and Email in datbase zit
                // Als dat zo is dan User already exist



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
                        Errors.Add(ve.ErrorMessage);
                    }
                }
                return Errors; 
            }
            
            

        }
        private string GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltBytes = new byte[36];
            rng.GetBytes(saltBytes);
            string salt = Convert.ToBase64String(saltBytes);

            return salt;

        }
        private string CalculateHashPassword(string Salt, string textPassword)
        {
            //Conver the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(textPassword + Salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            string password = Convert.ToBase64String(algorithm.ComputeHash(saltedHashBytes));

            return password;
             
        }
        /// <summary>
        /// We need to reset the user when logged out
        /// Set every item to null
        /// 
        /// </summary>
        public bool LogOut(User user)
        {
            user.Name = string.Empty;
            user.Password = string.Empty;
            user.Username = string.Empty;
            user.Role = string.Empty;

            return true;
            

        }

    }
}
