using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Globalization;
using InventoryControl.Data;
using InventoryControl.Areas.INV.Models;
using InventoryControl.Data.Views;

namespace InventoryControl.Areas.INV.Controllers
{
    [Area("INV")]
    [Produces("application/json")]
    public class ApiAprioriController : Controller
    {
        public readonly InventoryControlContext _context;
        public ApiAprioriController(InventoryControlContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> ProsesApriori(int? minsupport = 0, int? minconfidence = 0)
        {
            try
            {
                #region Global Variable
                var REQUESTHEADER = _context.RequestHeader.Include(x => x.RequestItem);
                var REQUEST = _context.vw_Request;
                var FREQUENTITEM = _context.vw_FrequentItem;
                var SUPPORT_C1 = _context.vw_Support;
                var COUNTREQUEST = REQUESTHEADER.Count();
                var MSTITEM = _context.MstItem;
                #endregion

                #region Iterasi - 1
                /**
                 * F1 = Frequent Item (dengan 1 himpunan data)
                 * Contoh: {Roti} saja, {Mentega} saja, {Telur} saja
                 * min support = dalam contoh adalah 2, sehingga yang dipilih hanya yang Support Count adalah 2 atau lebih
                 * */
                var F1 = SUPPORT_C1.Where(x => x.SupportCount >= minsupport);
                #endregion

                #region Iterasi - 2
                var Comb2 = F1.Join(F1, x => 1, y => 1, (x, y) => new { x, y })
                    .Select(a => new Fi2ViewModel
                    {
                        ItemId1 = a.x.ItemId,
                        Nama1 = a.x.Nama,
                        ItemId2 = a.y.ItemId,
                        Nama2 = a.y.Nama
                    });

                var F2 = new List<Fi2ViewModel>();
                var SUPPORT_C2 = new List<vw_Support>();
                foreach(var iComb2 in Comb2)
                {
                    var newC2 = REQUESTHEADER.Where(x => x.RequestItem.Any(y => y.ItemId == iComb2.ItemId1) && x.RequestItem.Any(y => y.ItemId == iComb2.ItemId2));

                    if(newC2.Count() > 0)
                    {
                        var countC2 = newC2.Count();
                        var newFiC2 = new Fi2ViewModel
                        {
                            ItemId1 = iComb2.ItemId1,
                            Nama1 = iComb2.Nama1,
                            ItemId2 = iComb2.ItemId2,
                            Nama2 = iComb2.Nama2,
                            SupportCount = countC2,
                            Support = countC2 / COUNTREQUEST
                        };

                        var newSupportC2 = new vw_Support
                        {
                            ItemSet = newFiC2.ItemId1.ToString()+","+newFiC2.ItemId2.ToString(),
                            SupportCount = (int)newFiC2.SupportCount,
                            Support = newFiC2.Support
                        };

                        F2.Add(newFiC2);
                        SUPPORT_C2.Add(newSupportC2);
                    }
                    
                }

                /**
                 * F2 = Frequent Item (dengan 2 himpunan data)
                 * Contoh: {Roti, Telur}, {Roti, Mentega}, dst...
                 * min support = dalam contoh adalah 2, sehingga yang dipilih hanya yang Support Count adalah 2 atau lebih
                 * */
                F2 = F2.Where(x => x.SupportCount >= minsupport).ToList();
                #endregion

                #region Iterasi - 3
                /*--- Choose table that contains item from F2 -----*/
                //var CandidateC3 = MSTITEM.Where(x => F2.Any(y => y.ItemId1 == x.Id || y.ItemId2 == x.Id));

                var F2Item1 = F2.Select(x => x.ItemId1).ToList();
                var F2Item2 = F2.Select(x => x.ItemId2).ToList();
                F2Item1.AddRange(F2Item2);
                var itemC3 = F2Item1.Distinct().ToList();

                var Comb3 = itemC3.Join(itemC3, x => 1, y => 1, (x, y) => new { x, y })
                    .Join(itemC3, a => 1, b => 1, (a, b) => new { a, b })
                    .Select(c => new Fi3ViewModel
                    {
                        ItemId1 = c.a.x,
                        Nama1 = c.a.x.ToString(),
                        ItemId2 = c.a.y,
                        Nama2 = c.a.y.ToString(),
                        ItemId3 = c.b,
                        Nama3 = c.b.ToString()
                    });

                var F3 = new List<Fi3ViewModel>();
                var SUPPORT_C3 = new List<vw_Support>();

                foreach (var iComb3 in Comb3)
                {
                    var newC3 = REQUESTHEADER.Where(x => x.RequestItem.Any(y => y.ItemId == iComb3.ItemId1) && x.RequestItem.Any(y => y.ItemId == iComb3.ItemId2) && x.RequestItem.Any(y => y.ItemId == iComb3.ItemId3));

                    if (newC3.Count() > 0)
                    {
                        var countC3 = newC3.Count();
                        var newFiC3 = new Fi3ViewModel
                        {
                            ItemId1 = iComb3.ItemId1,
                            Nama1 = iComb3.Nama1,
                            ItemId2 = iComb3.ItemId2,
                            Nama2 = iComb3.Nama2,
                            ItemId3 = iComb3.ItemId3,
                            Nama3 = iComb3.Nama3,
                            SupportCount = countC3,
                            Support = countC3 / COUNTREQUEST
                        };

                        var namaItemSet1 = await MSTITEM.SingleOrDefaultAsync(x => x.Id == newFiC3.ItemId1);
                        var namaItemSet2 = await MSTITEM.SingleOrDefaultAsync(x => x.Id == newFiC3.ItemId2);
                        var namaItemSet3 = await MSTITEM.SingleOrDefaultAsync(x => x.Id == newFiC3.ItemId3);

                        var newSupportC3 = new vw_Support
                        {
                            ItemSet = newFiC3.ItemId1.ToString() + ", " + newFiC3.ItemId2.ToString() + ", " + newFiC3.ItemId3.ToString(),
                            SupportCount = (int)newFiC3.SupportCount,
                            Support = newFiC3.Support,
                            NamaItemSet = namaItemSet1.Nama+", " + namaItemSet2.Nama + ", " + namaItemSet3.Nama
                        };

                        F3.Add(newFiC3);
                        SUPPORT_C3.Add(newSupportC3);
                    }

                }
                #endregion

                return Ok(SUPPORT_C3.Where(x => x.SupportCount > minsupport));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    
}
