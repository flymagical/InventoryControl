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
    [Area("INV")]
    [Authorize]
    public class AprioriController : BaseController
    {
        public readonly InventoryControlContext _context;
        public CommonService _commonService { get; set; }
        public int pageSize { get; set; }
        public AprioriController(InventoryControlContext context)
        {
            _context = context;
            pageSize = 10;
            _commonService = new CommonService(_context);
        }
        public async Task<IActionResult> Index(int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            ViewBag.ActiveClass = "link-apriori";
            var item = _context.vw_AprioriBidang.Select(x => new vw_AprioriBidang
            {
                Id = x.Id,
                CreatedDate = x.CreatedDate,
                ItemList = x.ItemList,
                Nama = x.Nama,
                Label = x.Label,
                Support = x.Support,
                StrCreatedDate = _commonService.GetSimpleIndonesianDateFormat(x.CreatedDate.Value)
            });

            var model = await PaginatedList<vw_AprioriBidang>.CreateAsync(item.AsNoTracking(), pageNumber ?? 1, pageSize);

            ViewBag.SelectBidang = _context.MstUnitOrg.Select(x => new { x.Id, x.Nama });
            return View(model);
        }
    }
}
