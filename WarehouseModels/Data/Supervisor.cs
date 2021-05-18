using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseModels
{
    public class Supervisor
    {
        public Supervisor() 
        {
            Workers = new List<Employee>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName {get; set;}

        [Required, StringLength(50)]
        public string LastName { get; set; }
        [Required, StringLength(50)]
        public string Username { get; set; }
        [Required, StringLength(50)]
        public string Password { get; set; }
        public ICollection<Employee> Workers { get; set; }

    }
}
