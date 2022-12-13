using InventoryControl.Controllers;
using InventoryControl.Data;
using InventoryControl.Models;
using InventoryControl.Models.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Areas.INV.Controllers
{
    [Area("INV")]
    [Authorize]
    public class MstItemController : BaseController
    {
        public readonly InventoryControlContext _context;
        public int pageSize { get; set; }
        public MstItemController(InventoryControlContext context)
        {
            
            _context = context;
            pageSize = 10;
        }
        public async Task<IActionResult> Index(int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            var mstItem = _context.MstItem
                          .Include(x => x.MstSatuan);
                          //.ToListAsync();
            ViewBag.ActiveClass = "link-barang";
            var model = await PaginatedList<MstItem>.CreateAsync(mstItem.AsNoTracking(), pageNumber ?? 1, pageSize);
            return View(model);
        }
    }
}
