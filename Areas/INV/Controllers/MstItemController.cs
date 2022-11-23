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
    public class MstItemController : Controller
    {
        public readonly InventoryControlContext _context;
        public MstItemController(InventoryControlContext context)
        {
            
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var mstItem = await _context.MstItem
                          .Include(x => x.MstSatuan)
                          .ToListAsync();
            ViewBag.ActiveClass = "link-barang";
            return View(mstItem);
        }
    }
}
