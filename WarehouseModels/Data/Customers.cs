using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseModels
{
    public class Customers
    {
        public Customers()
        {
            Orders = new List<Orders>();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Customer_Id")]
        public int Id { get; set; }
        [ForeignKey("Orders")]
        public int Order_Id { get; set; }
        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        [Required, StringLength(100)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Valid email required e.g. abc@xyz.com")]
        public string Email { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }
        [Required, StringLength(50)]
        public string Street { get; set; }
        [Required, StringLength(50)]
        public string Number { get; set; }
        [Required, StringLength(50)]
        public string City { get; set; }
        [Required, StringLength(50)]
        public string Country { get; set; }
        
        public int RegularCustomer { get; set; }

        public ICollection<Orders> Orders { get; set; }

        public string Fullname 
        {
            get { return $"{FirstName} {LastName}"; }

        }
    
    }
}
