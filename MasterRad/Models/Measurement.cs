using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterRad.Models
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public DateTime Timestamp { get; set; }
      
        public int BorderId { get; set; }
        public Border Border { get; set; }
    }
}
