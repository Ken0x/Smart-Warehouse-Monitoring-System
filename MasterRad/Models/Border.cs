using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterRad.Models
{
    public class Border
    {
        [Key]
        public int Id { get; set; }
        public float MaxTemperature { get; set; }
        public float MinTemperature { get; set; }
        public float MaxHumidity { get; set; }
        public float MinHumidity { get; set; }
        public int SectorsId { get; set; }
        public Sector Sector { get; set; }
        public int WarehousesId { get; set; }
        public Warehouse Warehouse { get; set; }
        public ICollection<Measurement> Measurements { get; set; }
        

    }
}
