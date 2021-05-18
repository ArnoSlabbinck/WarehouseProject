using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseModels
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Product_Id")]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string ProductName { get; set; }
        [Required]
        public string MadeIn { get; set; }
        
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("Suppliers")]
        public int SupplierId { get; set; }
        public DateTime ModelYear { get; set; }
        [Required]
        public double UnitPrice { get; set; }

        public int UnitsOnOrder { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; }
        
        public virtual Stocks Stocks { get; set; }
        
        public virtual Category Category { get; set; }
    
        public virtual Suppliers Suppliers { get; set; }
    }
}
