using InventoryControl.Data;
using InventoryControl.Data.Views;
using InventoryControl.Models;
using InventoryControl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static InventoryControl.Controllers.BaseController;

namespace InventoryControl.Areas.INV.Controllers
{
    [Area("INV")]
    [Authorize]
    [Produces("application/json")]
    public class ApiMovingAverageController : Controller
    {
        public readonly InventoryControlContext _context;
        public CommonService _commonService { get; set; }
        public ApiMovingAverageController(InventoryControlContext context)
        {
            _context = context;
            _commonService = new CommonService(_context);
        }

        [HttpPost]
        public async Task<IActionResult> ProsesMovingAverage(int? prevMonth = 0, int? predMonth = 0, string kdOrg = "", bool isForce = true)
        {
            try
            {
                if (isForce == true)
                {
                    var MOVINGAVERAGEBIDANG = _context.MovingAverageBidang;
                    var MSTITEM = _context.MstItem;
                    var MONTHLYREQUEST = _context.vw_Monthly_Request;

                    var maxYear = MONTHLYREQUEST.Where(x => x.KdOrg == kdOrg).Max(x => x.Tahun);
                    var maxMonth = MONTHLYREQUEST.Where(x => x.KdOrg == kdOrg && x.Tahun == maxYear).Max(x => x.Bulan);

                    List<vw_Monthly_Request> listOfCompleteItems = new List<vw_Monthly_Request>();
                    var endPeriod = DateTime.Parse(maxYear + "-" + maxMonth.ToString().PadLeft(2, '0') + "-15");
                    var startPeriod = endPeriod.AddMonths(-((prevMonth ?? 0) - 1));

                    var startIndex = startPeriod.Year * startPeriod.Month;

                    //supportCount from Apriori Calculation
                    var supportCount = _context.AprioriBidang
                                        .Include(x => x.AprioriBidangItem)
                                        .Where(x => x.KdOrg == kdOrg)
                                        .SelectMany(x => x.AprioriBidangItem);

                    var data = MONTHLYREQUEST
                                .Where(x => x.KdOrg == kdOrg)
                                /*
                                 * Implement item selection based on output of Apriori (SUPPORT COUNT)
                                 * **/
                                .Where(x => supportCount.Select(y => y.ItemId.ToString()).Contains(x.Id.ToString()))
                                /* --------------------------------------------------------------------------------- */
                                .OrderByDescending(x => x.ItemIndex)
                                .Where(x => x.ItemIndex >= startIndex);
                                //.Take((prevMonth* supportCount.Count()) ?? 0);

                    var uniqueItem = MONTHLYREQUEST.Select(x => x.Id).Distinct();
                    var newUniqueItem = new List<Guid>();
                    foreach(var iItem in uniqueItem)
                    {
                        var selectedItem = data.Where(x => x.Id == iItem);
                        if (selectedItem.Count() == prevMonth)        
                        {
                            listOfCompleteItems.AddRange(selectedItem);
                            newUniqueItem.Add(iItem);
                        }
                            
                    }

                    var newListOfCompleteItems = listOfCompleteItems;
                    
                    foreach(var iNewList in newListOfCompleteItems)
                    {
                        iNewList.RequestDate = DateTime.Parse(iNewList.Tahun.ToString() + "-" + iNewList.Bulan.ToString().PadLeft(2, '0') + "-15");
                    }

                    List<vw_Monthly_Request> predPeriod = new List<vw_Monthly_Request>();
                    for(int j = 1; j <= predMonth; j++)
                    {
                        var currPeriod = endPeriod.AddMonths(j);
                        var currMonth = currPeriod.Month;
                        var currYear = currPeriod.Year;

                        var startPredPeriod = endPeriod.AddMonths(-((predMonth ?? 0) - j + 1));
                        var endPredPeriod = startPredPeriod.AddMonths(((predMonth ?? 0) - 1));

                        List<MovingAverageBidang> newMovingAverageBidang = new List<MovingAverageBidang>();
                        foreach(var iList in newUniqueItem)
                        {
                            var newRequest = new vw_Monthly_Request();
                            newRequest.Id = iList;
                            newRequest.KdOrg = kdOrg;
                            newRequest.RequestDate = currPeriod;

                            var newData = newListOfCompleteItems.Where(x => x.Id == iList && x.RequestDate >= startPredPeriod && x.RequestDate <= endPeriod);

                            newRequest.JumlahTotalItem = (int)(newData.Sum(x => x.JumlahTotalItem)/predMonth);

                            var existingMAB = MOVINGAVERAGEBIDANG.Where(x => x.ItemId == iList && x.Bulan == currPeriod.Month && x.Tahun == currPeriod.Year && x.KdOrg == kdOrg);

                            if (existingMAB.Count() > 0)
                                _context.MovingAverageBidang.RemoveRange(existingMAB);

                            var newMAB = new MovingAverageBidang
                            {
                                Id = Guid.NewGuid(),
                                ItemId = iList,
                                Bulan = currPeriod.Month,
                                Tahun = currPeriod.Year,
                                Jumlah = newRequest.JumlahTotalItem,
                                KdOrg = kdOrg
                            };

                            _context.MovingAverageBidang.Add(newMAB);

                            newListOfCompleteItems.Add(newRequest);
                        }

                        await _context.SaveChangesAsync();
                    }
                }
                    
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet]
        public async Task<IActionResult> GetPredictedItem(int prevMonth, int predMonth, string kdOrg)
        {
            try
            {
                DateTime maxPeriod = _context.RequestHeader.Max(x => x.CreatedDate).Value;
                DateTime newPeriod = new DateTime(maxPeriod.Year, maxPeriod.Month, 1);


                DateTime startDate = newPeriod.AddMonths(1);
                DateTime endDateTemp = newPeriod.AddMonths(predMonth);
                DateTime endDate = new DateTime(endDateTemp.Year, endDateTemp.Month, DateTime.DaysInMonth(endDateTemp.Year, endDateTemp.Month));




                //var item = _context.vw_PredictedItem.Where(x => x.KdOrg == kdOrg && new DateTime(x.Tahun, x.Bulan, 1) >= startDate && new DateTime(x.Tahun, x.Bulan, 1) <= endDate)
                ;

                var item = _context.vw_PredictedItem.Where(x => x.KdOrg == kdOrg && x.TempDate >= startDate && x.TempDate <= endDate).OrderBy(x => x.Tahun).ThenBy(x => x.Bulan)
                ;
                return PartialView("~/Areas/INV/Views/MovingAverage/_PartialPredictedItem.cshtml", item.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
