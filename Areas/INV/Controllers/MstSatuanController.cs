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
    public class MstSatuanController : Controller
    {
        public readonly InventoryControlContext _context;
        public MstSatuanController(InventoryControlContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var mstSatuan = await _context.MstSatuan
                                  .ToListAsync();

            return View(mstSatuan);
        }
    }
}
