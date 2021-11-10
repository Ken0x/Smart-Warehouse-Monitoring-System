using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterRad.Models
{
    public class Sector
    {

        [Key]
        public int Id { get; set; }
        public string Sector_name{get; set; }
        
        public ICollection<Border> Border { get; set; }
    }
}
