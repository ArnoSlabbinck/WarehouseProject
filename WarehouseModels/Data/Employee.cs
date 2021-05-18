using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string Gender { get; set; }

        public int Salary { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }
        [Required]
        public string JobTitle { get; set; }

        [Display(Name = "Is Active")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "The field Is Active must be checked.")]
        public bool IsActive { get; set; }

        [Required, StringLength(50)]
        public string UserName { get; set; }
        //Store hashed password
        [Required]
        public string PassWord { get; set; }
        
        public string PassWordSalt { get; set; }

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
