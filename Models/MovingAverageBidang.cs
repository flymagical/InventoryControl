using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Models
{
    public class MovingAverageBidang
    {
        public Guid Id { get; set; }
        public int? Tahun { get; set; }
        public int? Bulan { get; set; }
        public Guid? ItemId { get; set; }
        public string KdOrg { get; set; }
        public int? Jumlah { get; set; }
    }
}
