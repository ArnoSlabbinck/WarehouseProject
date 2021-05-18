using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseModels
{
    public class Stocks
    {
        [Key]
        [ForeignKey("Products")]
        public int Id { get; set; }

        public int Quanity { get; set; }
        [Required]
        public virtual Products Products { get; set; }
    }
}
