using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseModels
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order_Id")]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string OrderStatus { get; set; }
       

        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShipDate { get; set; }
        public Customers customers { get; set; }
        public ICollection<OrderItems> orderItems { get; set; }




    }
}
