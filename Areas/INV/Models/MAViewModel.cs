using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Areas.INV.Models
{
    public class MAViewModel
    {
        public int PrevMonth { get; set; }
        public int PredMonth { get; set; }
        public string DefaultKdOrg { get; set; }
    }
}
