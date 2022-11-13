using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Models
{
    public class RequestItem
    {
        public Guid Id { get; set; }
        public Guid RequestHeaderId { get; set; }
        public Guid ItemId { get; set; }
        public int Jumlah { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("RequestHeaderId")]
        public RequestHeader RequestHeader { get; set; }
        [ForeignKey("ItemId")]
        public MstItem MstItem { get; set; }
    }
}
