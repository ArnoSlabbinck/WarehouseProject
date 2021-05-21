using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseModels
{
    public class Suppliers
    {
        public Suppliers()
        {
            Products = new List<Products>();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Supplier_Id")]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string CompanyName { get; set; }
    
        public string ContactName { get; set; }
        [Required, StringLength(50)]
        public string Address { get; set; }

        [Required, StringLength(50)]
        public string City { get; set; }

        [Required, StringLength(50)]
        public string PostCode { get; set; }

        [Required, StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
