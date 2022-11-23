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
using InventoryControl.Models;

namespace InventoryControl.Areas.INV.Controllers
{
    [Area("INV")]
    [Produces("application/json")]
    public class ApiAprioriController : Controller
    {
        public readonly InventoryControlContext _context;
        public List<ItemSetViewModel> itemSets;
        public ApiAprioriController(InventoryControlContext context)
        {
            _context = context;
            itemSets = new List<ItemSetViewModel>();
        }

        [HttpPost]
        public async Task<IActionResult> _ProsesApriori(int? minsupport = 0, int? minconfidence = 0)
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


        [HttpPost]
        public async Task<IActionResult> ProsesApriori(int? minsupport = 0, int? minconfidence = 0, string kdOrg = "")
        {
            int k = 1;
            var MSTITEM = _context.MstItem;
            List<ItemSetViewModel> ItemSets = new List<ItemSetViewModel>();
            List<AssociationRuleViewModel> allRules = new List<AssociationRuleViewModel>();
            var userListInUnitOrg = _context.MstUser.Where(x => x.KdOrg == kdOrg);
            var REQUEST = _context.RequestHeader.Include(x => x.RequestItem).Where(x => userListInUnitOrg.Any(y => y.Id.ToString() == x.UserId));

            var requestItem = new List<RequestItem>();
            foreach (var iRequest in REQUEST)
            {
                requestItem.AddRange(iRequest.RequestItem);
            }

            var mstitem = _context.MstItem.Where(x => requestItem.Select(y => y.ItemId.ToString()).Contains(x.Id.ToString())).Select(x => x.Id).AsEnumerable();

            bool next;
            do
            {
                next = false;
                var iset = GetItemSet(k, (int)minsupport, mstitem.AsEnumerable(), REQUEST, false);
                if(iset.Count() > 0)
                {
                    List<AssociationRuleViewModel> rules = new List<AssociationRuleViewModel>();
                    if (k != 1)
                    {
                        rules = GetRules(iset);
                        allRules.AddRange(rules);
                    }
                        

                    next = true;
                    k++;
                    ItemSets.Add(iset);

                }
            } while (next);
            
            foreach(var iSet in ItemSets)
            {
                List<string> barangBarang = new List<string>();
                foreach(var iKeys in iSet.Keys)
                {
                    string barang = "";
                    int i = 0;
                    foreach(var iKey in iKeys)
                    {
                        var item = await MSTITEM.SingleOrDefaultAsync(x => x.Id == iKey);
                        if (i == 0)
                        {
                            barang += item.Nama;
                        }
                        else
                        {
                            barang += ", " + item.Nama;
                        }
                    }
                    barangBarang.Add(barang);
                }
                
            }

            return Ok(ItemSets);
        }

        public ItemSetViewModel GetItemSet(int length, int minsupport, IEnumerable<Guid> mstitem, IQueryable<RequestHeader> REQUEST, bool candidates = false)
        {
            
            List<List<Guid>> result = GetPermutations(mstitem, length).Select(x => x.ToList()).ToList();
            List<List<Guid>> data = new List<List<Guid>>();
            foreach (var item in result)
            {
                data.Add(item.ToList());
            }
            ItemSetViewModel itemSet = new ItemSetViewModel();
            itemSet.Support = minsupport;
            itemSet.Label = (candidates ? "C" : "L") + length.ToString();
            foreach (var item in data)
            {
                int count = 0;
                foreach(var iRequest in REQUEST)
                {
                    bool found = false;
                    foreach(var iList in item)
                    {
                        if (iRequest.RequestItem.Any(x => x.ItemId == iList))
                            found = true;
                        else
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                        count++;
                }
                if(count >= minsupport)
                {
                    itemSet.Add(item, count);
                    itemSets.Add(itemSet);
                }
            }

            return itemSet;
        }
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }

                ++i;
            }
        }

        public List<AssociationRuleViewModel> GetRules(ItemSetViewModel items)
        {
            List<AssociationRuleViewModel> rules = new List<AssociationRuleViewModel>();
            foreach (var item in items)
            {
                foreach (var set in item.Key)
                {
                    rules.Add(GetSingleRule(set.ToString(), item));
                    if (item.Key.Count > 2)
                        rules.Add(GetSingleRule(item.Key.ToString(), item));
                }
            }

            return rules.OrderByDescending(a => a.Support).ThenByDescending(a => a.Confidence).ToList();
        }

        private AssociationRuleViewModel GetSingleRule(string set, KeyValuePair<List<Guid>, int> item)
        {
            var setItems = set.ToString().Split(',');
            for (int i = 0; i < setItems.Count(); i++)
            {
                setItems[i] = setItems[i].Trim();
            }
            AssociationRuleViewModel rule = new AssociationRuleViewModel();
            StringBuilder sb = new StringBuilder();
            sb.Append(set).Append(" => ");
            List<string> list = new List<string>();
            foreach (var set2 in item.Key)
            {
                if (setItems.Contains(set2.ToString())) continue;
                list.Add(set2.ToString());
            }

            //sb.Append(list.ToDisplay()) ;
            rule.Label = sb.ToString();
            int totalSet = 0;
            foreach (var first in itemSets)
            {
                var myItem = first.Keys.Where(a => a.ToString() == set);
                if (myItem.Count() > 0)
                {
                    first.TryGetValue(myItem.FirstOrDefault(), out totalSet);
                    break;
                }
            }
            rule.Confidence = Math.Round(((double)item.Value / totalSet) * 100, 2);
            rule.Support = Math.Round(((double)item.Value / list.Count) * 100, 2);
            return rule;
        }
    }

    
}
