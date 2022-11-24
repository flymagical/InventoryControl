using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Models
{
    public class AprioriBidang
    {
        public Guid Id { get; set; }
        public string KdOrg { get; set; }
        public string Label { get; set; }
        public int? Support { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ICollection<AprioriBidangItem> AprioriBidangItem { get; set; }
    }
}
