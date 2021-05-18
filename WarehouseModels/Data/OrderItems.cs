using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseModels
{
    public class OrderItems
    {
        public int Id { get; set; }
       
        public int Product_Id { get; set; }

        public int Quantity { get; set; }

        public double TotalPriceWithoutTax { get; set; }

        public double PriceWithTax { get; set; }
        
        
        public Orders Orders { get; set; }

        
        public Products Products { get; set; }
        
    }
}
