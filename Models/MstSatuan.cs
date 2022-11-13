using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Models
{
    public class MstSatuan
    {
        public Guid Id { get; set; }
        public string Nama { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public ICollection<MstItem> MstItem { get; set; }
    }
}
