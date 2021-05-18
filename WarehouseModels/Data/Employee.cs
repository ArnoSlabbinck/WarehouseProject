using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit;

namespace WarehouseModels
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Employee_Id")]
        public int Id { get; set; }
        [ForeignKey("Orders")]
        public int Order_Id { get; set; }

        [Required(ErrorMessage = "An FirstName is required"), StringLength(50, ErrorMessage = "Value lies outside the 1 to 50 range")]
        public string FirstName { get; set; }
        [Required, StringLength(50, ErrorMessage = "Value lies outside the 1 to 50 range")]
        public string Gender { get; set; }

        public int Salary { get; set; }
        [Required(ErrorMessage = "An LastName is required"), StringLength(50, ErrorMessage = "Value lies outside the 1 to 50 range")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "An Email is required"), StringLength(100, ErrorMessage = "Value lies outside the 1 to 100 range")]
        public string Email { get; set; }
        [Required]
        public string JobTitle { get; set; }

        [Display(Name = "Is Active")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "The field Is Active must be checked.")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "An UserName is required"), StringLength(50, ErrorMessage="Value lies outside the 1 to 50 range")]
        public string UserName { get; set; }
        //Store hashed password
        [Required(ErrorMessage = "An Password is required")]
        public string PassWord { get; set; }
        
        public string PassWordSalt { get; set; }
        [Range(0,3, ErrorMessage = "Password Attempts can't be higher than 3 tries") ]
        public int FailedPasswordAttemptCount { get; set; }

        public string FullName() => $"{FirstName} {LastName}";


        //After 3 failed attempts lock account out
        public bool IsLockedOut { get; set; } = false;

        //Update when user logged out
        public DateTime LastLoginDate { get; set; } = DateTime.Now; 
        
        public Supervisor Supervisor { get; set; }

        public ICollection<Orders> Orders { get; set; }

    }
}
