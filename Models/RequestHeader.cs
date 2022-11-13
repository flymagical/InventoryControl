using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Models
{
    public class RequestHeader
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public int StatusId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        [ForeignKey("StatusId")]
        public MstStatus MstStatus { get; set; }

        public ICollection<RequestItem> RequestItem { get; set; }
    }
}
