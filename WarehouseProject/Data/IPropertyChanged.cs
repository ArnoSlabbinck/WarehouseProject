using System;

namespace WarehouseProject.Data
{
    internal interface IPropertyChangedRegistration
    {
       
        DateTime DateOfBirth
        {
            get;
            set;
        }

        string Lastname
        {
            get;
            set;
            
        }

       

        string Email
        {
            get;
            set;
        }


        
        int Firstname
        {
            get;
            set;
        }




        string Mobile
        {
            get;
            set;
        }



        string JobTitle
        {
            get;
            set;
        }



    
        string Password
        {
            get;
            set;
        }
    }
}