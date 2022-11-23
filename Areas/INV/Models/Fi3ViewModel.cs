using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Areas.INV.Models
{
    public class Fi3ViewModel
    {
        public Guid ItemId1 { get; set; }
        public string Nama1 { get; set; }
        public Guid ItemId2 { get; set; }
        public string Nama2 { get; set; }
        public Guid ItemId3 { get; set; }
        public string Nama3 { get; set; }
        public int? SupportCount { get; set; }
        public decimal? Support { get; set; }
    }
}
