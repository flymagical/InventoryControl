using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Data.Views
{
    public class vw_Monthly_Request
    {
        public Guid Id { get; set; }
        public string Nama { get; set; }
        public Guid SatuanId { get; set; }
        public string KdOrg { get; set; }
        public int? Tahun { get; set; }
        public int? Bulan { get; set; }
        public int? JumlahTotalItem { get; set; }
        public int? ItemIndex { get; set; }
        [NotMapped]
        public DateTime? RequestDate { get; set; }
    }
}
