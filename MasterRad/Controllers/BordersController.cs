using MasterRad.Data;
using MasterRad.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MasterRad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BordersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BordersController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Border>> Get([FromQuery] int warehouseId, [FromQuery] int sectorId)
        {
            return await _context.Borders
                    .Where(border => border.WarehousesId == warehouseId && border.SectorsId == sectorId)
                    .Include(border => border.Warehouse)
                    .Include(border => border.Sector)
                    .Include(border => border.Measurements)
                    .ToListAsync();
        }
        [HttpGet("sectors")]
        public async Task<List<Sector>> Get([FromQuery] int warehouseId)
        {
            return await _context.Borders
                    .Where(border => border.WarehousesId == warehouseId)
                    .Include(border => border.Sector)
                    .Select(border => border.Sector)
                    .ToListAsync();
        }

    }
}

