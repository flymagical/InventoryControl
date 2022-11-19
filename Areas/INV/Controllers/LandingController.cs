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
    public class LandingController : Controller
    {
        public readonly InventoryControlContext _context;
        public LandingController(InventoryControlContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _context.RequestHeader
                                .Include(x => x.RequestItem)
                                    .ThenInclude(y => y.MstItem)
                                .Include(x => x.MstStatus)
                                //.FirstOrDefaultAsync()
                                .ToListAsync()
                                ;
            return View(item);
        }
    }
}
