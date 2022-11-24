using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Data.Views
{
    public class vw_AprioriBidang
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string KdOrg { get; set; }
        public string Nama { get; set; }
        public int? Support { get; set; }
        public string Label { get; set; }
        public string ItemList { get; set; }
        [NotMapped]
        public string StrCreatedDate { get; set; }
    }
}
