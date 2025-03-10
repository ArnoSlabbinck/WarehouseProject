﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels;

namespace WarehouseProject.Data
{
    public class DataValidationService
        : IDataValidation
    {

        Dictionary<string, List<CustomAttributeData>> ErrorCollection = new Dictionary<string, List<CustomAttributeData>>();
        Employee employee = new Employee();

        List<string> errors = new List<string>();
        string[] employeeData = new string[9];
        newEmployeeParams employeeParams = new newEmployeeParams();
        // Get the 
        public IEnumerable GetErrors(string propertyName)
        {
            // Put the errors from the data annotations 
            if (string.IsNullOrEmpty(propertyName) || (!HasErrors))
                return null;
            return new List<string>() { ErrorCollection[propertyName].ToString() };
        }
        public bool HasErrors { get; set; } = false;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        /// Takes the data from User 
        /// </summary>
        /// <param name="dataOfNewEmployee"></param>
        /// <param name="auth"></param>
        /// <returns></returns>
        public List<string> CheckRegistration(string dataOfNewEmployee, AuthenticationService auth)
        {
            //Separate the data into keys 
            // Take the attributes from the employee properties and use it as errors 
            // 
            employeeData = dataOfNewEmployee.Split(',');
            BindEmplMembers(employeeData);
            
            getAttributesPropertiesFromClass(employee);

            Console.WriteLine($"{employeeParams.FirstName} {employeeParams.BirthDate}");
            List<string> errors = auth.Register(employeeParams);
            

            HasErrors = !string.IsNullOrEmpty(errors[0]);
            if (HasErrors == true)
            {
                return errors;
            }
            else {

                return null;
            
            }

            
        }


        // Get the requirements from the 

        public void getAttributesPropertiesFromClass(Object obj)
        {
            try
            {
                
                // Get the type of MyClass1.
                Type myType = obj.GetType();
                // Get the members associated with MyClass1.
                MemberInfo[] myMembers = myType.GetMembers();
                List<string> attributesMyMember = new List<string>();
                // Display the attributes for each of the members of Employee
                for (int i = 0; i < myMembers.Length; i++)
                {
                    Object[] myAttributes = myMembers[i].GetCustomAttributes(true);
                    if (myAttributes.Length > 0)
                    {
                        Console.WriteLine("\nThe attributes for the member {0} are: \n", myMembers[i]);
                        ErrorCollection.Add(myMembers[i].Name, myMembers[i].CustomAttributes.ToList());

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occurred: {0}", e.Message);
            }


        }

        private void BindEmplMembers(string[] emp)
        {
            employeeParams.FirstName = emp[0].Trim();
            employeeParams.LastName = emp[1].Trim();
            employeeParams.Username = emp[2].Trim();
            employeeParams.Password = emp[3].Trim();
            employeeParams.Salaries = Convert.ToInt32(emp[4]);
            employeeParams.JobTitle = emp[5].Trim();
            employeeParams.Email = emp[6].Trim();
            employeeParams.Gender = emp[7].Trim();
            employeeParams.BirthDate = Convert.ToDateTime(emp[8].Trim());
            
        }
    }

    public class newEmployeeParams
    {
        private int id = 0;
        public int Id {
            get { return id; } 
            set { id = value; }
        }
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public String Password { get; set; }
        public int Salaries { get; set; }
        public String JobTitle { get; set; }
        public string Email { get; set; }
        public string Fullname { get
            {
                return $"{FirstName} {LastName}";
            } 
        }
        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }
        public override string ToString()
        {
            return $"{FirstName}, {LastName}, {Gender}";
        }

    }
}
