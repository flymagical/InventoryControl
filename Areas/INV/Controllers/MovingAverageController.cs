using InventoryControl.Areas.INV.Models;
using InventoryControl.Data;
using InventoryControl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static InventoryControl.Controllers.BaseController;

namespace InventoryControl.Areas.INV.Controllers
{
    [Area("INV")]
    [Authorize]
    public class MovingAverageController : Controller
    {
        public readonly InventoryControlContext _context;
        public CommonService _commonService { get; set; }
        public int pageSize { get; set; }
        public MovingAverageController(InventoryControlContext context)
        {
            _context = context;
            pageSize = 10;
            _commonService = new CommonService(_context);
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            ViewBag.ActiveClass = "link-movingaverage";
            ViewBag.SelectBidang = _context.MstUnitOrg.Select(x => new { x.Id, x.Nama });
            string defaultKdOrg = _context.MstUnitOrg.FirstOrDefaultAsync().Result.Id;
            int maxYear = _context.vw_Monthly_Request.Max(x => x.Tahun).Value;
            int maxMonth = _context.vw_Monthly_Request.Max(x => x.Bulan).Value;

            var model = new MAViewModel
            {
                PrevMonth = 3,
                PredMonth = 3,
                LastMonth = maxMonth.ToString().PadLeft(2,'0')+"-"+maxYear.ToString(),
                DefaultKdOrg = defaultKdOrg
            };
            return View(model);
        }
    }
}
