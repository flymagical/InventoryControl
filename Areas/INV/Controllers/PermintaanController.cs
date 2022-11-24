using InventoryControl.Controllers;
using InventoryControl.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Areas.INV.Controllers
{
    [Area ("INV")]
    [Authorize]
    public class PermintaanController : BaseController
    {
        public readonly InventoryControlContext _context;
        public PermintaanController(InventoryControlContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _context.RequestHeader
                            .Include(x => x.RequestItem)
                            .ToListAsync();
            var USER = _context.MstUser;
            foreach(var iItem in item)
            {
                iItem.UserName = USER.SingleOrDefaultAsync(x => x.Id == Guid.Parse(iItem.UserId)).Result.Nama;
            }
            ViewBag.ActiveClass = "link-permintaan";
            return View(item);
        }
    }
}
