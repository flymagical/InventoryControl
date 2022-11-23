using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Areas.INV.Models
{
    public class AssociationRuleViewModel
    {
        public string Label { get; set; }
        public double Confidence { get; set; }
        public double Support { get; set; }
    }
}
