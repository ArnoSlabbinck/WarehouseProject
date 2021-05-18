using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseModels
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Category_Id")]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string CategoryName { get; set; }

        
        [Required, StringLength(250)]
        public string Description { get; set; }

        
        public ICollection<Products> product { get; set; }
    }
}
