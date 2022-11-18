using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Models
{
    public class Stok
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public int? Jumlah { get; set; }
        [ForeignKey("ItemId")]
        public MstItem MstItem { get; set; }
    }
}
