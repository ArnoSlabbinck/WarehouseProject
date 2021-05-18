using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseModels
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Brand_Id")]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string BrandName { get; set; }
        [Required]
        public ICollection<Products> Products { get; set; }
    }
}
