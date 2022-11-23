using InventoryControl.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Areas.INV.Controllers
{
    [Area("INV")]
    public class AprioriController : Controller
    {
        public readonly InventoryControlContext _context;
        public AprioriController(InventoryControlContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _context.vw_Request.ToListAsync();
            ViewBag.ActiveClass = "link-apriori";
            return View(item);
        }
    }
}
