using InventoryControl.Controllers;
using InventoryControl.Data;
using InventoryControl.Data.Views;
using InventoryControl.Models.Components;
using InventoryControl.Services;
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
        public CommonService _commonService { get; set; }
        public int pageSize { get; set; }
        public PermintaanController(InventoryControlContext context)
        {
            _context = context;
            pageSize = 10;
            _commonService = new CommonService(_context);
        }
        public async Task<IActionResult> Index(int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            ViewBag.ActiveClass = "link-permintaan";
            var item = _context.vw_Request.OrderByDescending(x => x.CreatedDate).Select(x => new vw_Request
            {
                Id = x.Id,
                CreatedDate = x.CreatedDate,
                ItemList = x.ItemList,
                StrCreatedDate = _commonService.GetSimpleIndonesianDateFormat(x.CreatedDate.Value)
            });

            var model = await PaginatedList<vw_Request>.CreateAsync(item.AsNoTracking(), pageNumber ?? 1, pageSize);

            ViewBag.SelectBidang = _context.MstUnitOrg.Select(x => new { x.Id, x.Nama });
            return View(model);
        }
    }
}
