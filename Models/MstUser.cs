using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Models
{
    public class MstUser
    {
        [Key]
        public Guid Id { get; set; }
        public string Nama { get; set; }
        public string Password { get; set; }
        public string NIP { get; set; }
        public string KdOrg { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        [ForeignKey("KdOrg")]
        public MstUnitOrg MstUnitOrg { get; set; }
    }
}
