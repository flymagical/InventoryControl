using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Data.Views
{
    public class vw_Support
    {
        public Guid ItemId { get; set; }
        public string Nama { get; set; }
        public Guid SatuanId { get; set; }
        public int SupportCount { get; set; }
        public decimal? Support { get; set; }
        [NotMapped]
        public string ItemSet { get; set; }
        [NotMapped]
        public string NamaItemSet { get; set; }
    }
}
