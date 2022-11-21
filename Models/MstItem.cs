using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Models
{
    public class MstItem
    {
        public Guid Id { get; set; }
        public string Nama { get; set; }
        public Guid SatuanId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("SatuanId")]
        public MstSatuan MstSatuan { get; set; }
        public ICollection<RequestItem> RequestItem { get; set; }
        public ICollection<Stok> Stok { get; set; }

       
    }
}
