using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Areas.INV.Models
{
    public class AprioriViewModel
    {
        public int MinSupport { get; set; }
        public int MinConfidence { get; set; }
        public string DefaultKdOrg { get; set; }
    }
}
