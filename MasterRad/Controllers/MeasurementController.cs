using MasterRad.Data;
using MasterRad.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterRad.Controllers
{
    public class MeasurementController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MeasurementController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()

        {

            IEnumerable<SelectListItem> TypeDropDown = _context.Borders.Select(i => new SelectListItem
            {
                Text = i.Warehouse.Warehouse_name,
                Value = i.WarehousesId.ToString()
            }).Distinct();
            var firstWarehouse = TypeDropDown.First().Value;

            IEnumerable<SelectListItem> DropDown = _context.Borders.Where(b => b.WarehousesId.ToString() == firstWarehouse).Select(i => new SelectListItem
            {
                Text = i.Sector.Sector_name,
                Value = i.SectorsId.ToString()
            });
            ViewBag.TypeDropDown = TypeDropDown;
            ViewBag.DropDown = DropDown;
            return View();
        }

    }
}
