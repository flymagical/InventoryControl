using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Data.Views
{
    public class vw_PredictedItem
    {
        public Guid Id { get; set; }
        public int Tahun { get; set; }
        public int Bulan { get; set; }
        public Guid ItemId { get; set; }
        public int Jumlah { get; set; }
        public string KdOrg { get; set; }
        public string NamaBidang { get; set; }
        public string NamaItem { get; set; }
        public Guid SatuanId { get; set; }
        public string NamaSatuan { get; set; }
        public DateTime? TempDate { get; set; }



    }
}
