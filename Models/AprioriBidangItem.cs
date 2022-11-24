using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Models
{
    public class AprioriBidangItem
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public Guid AprioriBidangId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        [ForeignKey("AprioriBidangId")]
        public AprioriBidang AprioriBidang { get; set; }
        [ForeignKey("ItemId")]
        public MstItem MstItem { get; set; }
    }
}
