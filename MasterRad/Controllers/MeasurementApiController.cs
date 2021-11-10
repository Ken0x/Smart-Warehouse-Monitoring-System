using MasterRad.Data;
using MasterRad.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterRad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MeasurementApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/MeasurementApi
        [HttpPost]
        public async Task<ActionResult<Measurement>>PostMeasurement([FromBody] Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                measurement.Timestamp = System.DateTime.Now;
                await _context.AddAsync(measurement);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMeasurement", new { id = measurement.Id }, measurement);
            }
            return Ok(measurement);
        }
        [HttpGet]
        public async Task<List<Measurement>> Get([FromQuery] int sectorId, [FromQuery] int warehouseId)
        {
            return await _context.Measurements.Include(b => b.Border).Where(b => b.Border.SectorsId == sectorId && b.Border.WarehousesId == warehouseId).OrderByDescending(m => m.Timestamp).Take(50).ToListAsync();
        }

    }
}
