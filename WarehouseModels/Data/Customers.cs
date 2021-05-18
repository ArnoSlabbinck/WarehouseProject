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
        public string Email { get; set; }
        [StringLength(50)]
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

    }
}
