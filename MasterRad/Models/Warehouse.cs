using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterRad.Models
{
    public class Warehouse
    {

        [Key]
        public int Id { get; set; }
        public string Warehouse_name { get; set; }
        public ICollection<Border> Border { get; set; }
       
    }
}
