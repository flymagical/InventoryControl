using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Data.Views
{
    public class vw_FrequentItem
    {
        public Guid ItemId { get; set; }
        public string Nama { get; set; }
        public Guid SatuanId { get; set; }
        public int? SupportCount { get; set; }
    }
}
